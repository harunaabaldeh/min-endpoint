using MinimalApi.Endpoint;
using MinimalApiEndpoint.Data;
using MinimalApiEndpoint.Features.Posts.Commands.CreateUserPost.Contracts;
using MinimalApiEndpoint.Models;

namespace MinimalApiEndpoint.Features.Posts.Commands.CreateUserPost
{
    public class CreateUserPostEndpoint : IEndpoint<CreateUserPostResponse, CreateUserPostRequest>
    {
        private readonly AppDbContext _context;
        public CreateUserPostEndpoint(AppDbContext context)
        {
            _context = context;

        }
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPost("/post", (Post post) => HandleAsync(new CreateUserPostRequest { Post = post }));
        }

        public async Task<CreateUserPostResponse> HandleAsync(CreateUserPostRequest request)
        {
            var newPost = new Post
            {
                Content = request.Post.Content,
                DateCreated = DateTime.Now
            };

            await _context.Posts.AddAsync(newPost);
            await _context.SaveChangesAsync();

            return new CreateUserPostResponse
            {
            };
        }
    }
}