using API_TEST_NET.DTOs;
using System.Text.Json;

namespace API_TEST_NET.Services
{
    public class PostService : IPostService
    {
        private HttpClient _httpClient;

        public PostService(HttpClient httClient)
        {
            _httpClient = httClient;
        }

        public async Task<IEnumerable<PostDto>> Get()
        {

            var result = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var body = await result.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var post = JsonSerializer.Deserialize<IEnumerable<PostDto>>(body, options);

            return post;
        }
    }
}
