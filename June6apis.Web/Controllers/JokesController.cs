using June5apis.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace June6apis.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly string _connectionString;
        public JokesController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }
        [HttpGet]
        [Route("getnewjoke")]
        public Joke GetNewJoke()
        {
            var joke = JokesApi.GetJoke();
            var repo = new JokesRepository(_connectionString);
            repo.AddJoke(joke);
            var j = repo.GetJokeByOriginId(joke.OriginId);
            return j;
        }
    }
}
