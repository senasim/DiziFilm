using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DiziFilm.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvShowsController : ControllerBase
    {
        private readonly  IHttpClientFactory _httpClientFactory;
        private readonly string _apiKey = "a82ff6a0a46b16c702e6c82d3e8b760a";


        public TvShowsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory= httpClientFactory;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string query)
        {
            var client=_httpClientFactory.CreateClient();
            var response = await client.GetStringAsync($"https://api.themoviedb.org/3/search/tv?api_key={_apiKey}&query={query}&language=tr-TR");

            var result=JsonDocument.Parse(response);
            var tvList = result.RootElement.GetProperty("results");

            return Ok(tvList);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync($"https://api.themoviedb.org/3/tv/{id}?api_key={_apiKey}&language=tr-TR");

            var tv = JsonDocument.Parse(response).RootElement;
            return Ok(tv);
        }
    }
}
