using MinimalApiEndpoint.Models;

namespace MinimalApiEndpoint.Features.Posts.Queries.GetAllUserPosts.Contracts
{
    public class GetAllUserPostsResponse
    {
        public List<Post> Post { get; set; }
    }
}