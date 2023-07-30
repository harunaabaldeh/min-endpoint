using Microsoft.EntityFrameworkCore;
using MinimalApi.Endpoint;
using MinimalApiEndpoint.Data;
using MinimalApiEndpoint.Features.Posts.Queries.GetAllUserPosts.Contracts;

namespace MinimalApiEndpoint.Features.Posts.Queries.GetAllUserPosts
{
    public class GetAllUserPostsEndpoint : IEndpoint<GetAllUserPostsResponse, GetAllUserPostsRequest>
    {
        private readonly AppDbContext _context;
        public GetAllUserPostsEndpoint(AppDbContext context)
        {
            _context = context;

        }

        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("/post", async () => await HandleAsync(new GetAllUserPostsRequest()));
        }

        public async Task<GetAllUserPostsResponse> HandleAsync(GetAllUserPostsRequest request)
        {
            var userPosts = await _context.Posts.ToListAsync();

            return new GetAllUserPostsResponse
            {
                Post = userPosts
            };
        }
    }
}