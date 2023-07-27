using Microsoft.EntityFrameworkCore;
using MinimalApi.Endpoint;
using MinimalApiEndpoint.Data;
using MinimalApiEndpoint.Features.Posts.Queries.GetUserPostById.Contracts;

namespace MinimalApiEndpoint.Features.Posts.Queries.GetUserPostById
{
    public class GetPostbyIdEndpoint : IEndpoint<IResult, GetPostByIdRequest>
    {
        private readonly AppDbContext _context;
        public GetPostbyIdEndpoint(AppDbContext context)
        {
            _context = context;

        }

        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("/posts/{userPostId}", (int userPostId) => HandleAsync(new GetPostByIdRequest { PostId = userPostId }));
        }

        public async Task<IResult> HandleAsync(GetPostByIdRequest request)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == request.PostId);

            return Results.Json(new GetPostByIdResponse
            {
                Content = post.Content,
            });

        }
    }
}