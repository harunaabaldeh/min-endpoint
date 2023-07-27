using MinimalApiEndpoint.Models;

namespace MinimalApiEndpoint.Features.Posts.Commands.UpdateUserPost.Contracts
{
    public class UpdateUserPostRequest
    {
        public Post Post { get; set; }
    }
}