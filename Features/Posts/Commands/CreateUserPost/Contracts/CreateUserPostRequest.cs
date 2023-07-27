using MinimalApiEndpoint.Models;

namespace MinimalApiEndpoint.Features.Posts.Commands.CreateUserPost.Contracts
{
    public class CreateUserPostRequest
    {
        public Post Post { get; set; }
    }
}