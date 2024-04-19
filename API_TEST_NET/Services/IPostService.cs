using API_TEST_NET.DTOs;

namespace API_TEST_NET.Services
{
    public interface IPostService
    {
        public Task<IEnumerable<PostDto>> Get();
    }
}
