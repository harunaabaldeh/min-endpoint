using Microsoft.EntityFrameworkCore;
using MinimalApi.Endpoint;
using MinimalApiEndpoint.Data;
using MinimalApiEndpoint.Features.Posts.Commands.DeleteUserPost.Contracts;

namespace MinimalApiEndpoint.Features.Posts.Commands.DeleteUserPost
{
    public class DeleteUserPostEndpoint : IEndpoint<IResult, DeleteUserPostRequest>
    {
        private readonly AppDbContext _context;
        public DeleteUserPostEndpoint(AppDbContext context)
        {
            _context = context;
        }

        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapDelete("/posts/{postId}", (int postId) => HandleAsync(new DeleteUserPostRequest { userPostId = postId }));
        }

        public async Task<IResult> HandleAsync(DeleteUserPostRequest request)
        {
            var post = _context.Posts.Find(request.userPostId);

            if (post == null) return Results.NotFound();

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return Results.Json(new DeleteUserPostResponse
            {

            });
        }
    }
}