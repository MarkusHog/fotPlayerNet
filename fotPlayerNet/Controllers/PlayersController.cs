using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using Microsoft.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fotPlayerNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {

        public record Player
        {
            //public int Id { get; set; }
            public string Name { get; set; }
            public string Position { get; set; }
            public string  Team { get; set; }
        }

     

        private readonly HttpClient _httpClient;

        public PlayersController(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
        // GET: api/<PlayersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _httpClient.GetAsync("https://fotplayers.azurewebsites.net/players");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("There was an error");
            }
            
            var data = await response.Content.ReadAsStringAsync();

            return Ok(data);
        }



        //// GET api/<PlayersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var response = await _httpClient.GetAsync($"https://fotplayers.azurewebsites.net/players/{id}");
            
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("There was an error");
            }

            var data = await response.Content.ReadAsStringAsync();
            return Ok(data);
        }

        //// POST api/<PlayersController>
        [HttpPost]

        public async Task<IActionResult> Post(Player player)
        {
            
            var response = await _httpClient.PostAsJsonAsync("https://fotplayers.azurewebsites.net/addplayer", player);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("There was an error");
            }
            var data = await response.Content.ReadAsStringAsync();
            return Ok(data);
        }

        //// PUT api/<PlayersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,Player player)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://fotplayers.azurewebsites.net/update/{id}", player);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("There was an error");
            }
            var data = await response.Content.ReadAsStringAsync();
            return Ok(data);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://fotplayers.azurewebsites.net/deleteplayer/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("There was an error");
            }
            var data = await response.Content.ReadAsStringAsync();
            return Ok(data);
        }
       
    }
}
