using MinimalApi.Endpoint;
using MinimalApiEndpoint.Data;
using MinimalApiEndpoint.Features.Posts.Commands.UpdateUserPost.Contracts;
using MinimalApiEndpoint.Models;

namespace MinimalApiEndpoint.Features.Posts.Commands.UpdateUserPost
{
    public class UpdateUserPostEndpoint : IEndpoint<IResult, UpdateUserPostRequest>
    {
        private readonly AppDbContext _context;
        public UpdateUserPostEndpoint(AppDbContext context)
        {
            _context = context;

        }
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPut("post/{userPostId}", (int userPostId) => HandleAsync(new UpdateUserPostRequest { Id = userPostId }));
        }

        public async Task<IResult> HandleAsync(UpdateUserPostRequest request)
        {
            var post = await _context.Posts.FindAsync(request.Id);

            var updatePost = new Post
            {
                Content = post.Content,
                LastModified = DateTime.Now
            };

            _context.Posts.Update(updatePost);
            await _context.SaveChangesAsync();

            return Results.Ok(updatePost);
        }

    }
}