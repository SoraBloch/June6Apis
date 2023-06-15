using June5apis.Data;
using June6apis.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
        [Route("getcounts/{jokeId}")]
        public object GetCounts(int jokeId)
        {
            var repo = new JokesRepository(_connectionString);
            var joke = repo.GetJokeWithLikes(jokeId);
            return new
            {
                likesCount = joke.UserLikedJokes.Where(j => j.Status == Status.Liked).Count(),
                dislikesCount = joke.UserLikedJokes.Where(j => j.Status == Status.Disliked).Count()
            };
        }
        [HttpGet]
        [Route("getstatus/{jokeId}")]
        public string GetStatus(int jokeId)
        {
            var userRepo = new UserRepository(_connectionString);
            var user = userRepo.GetByEmail(User.Identity.Name);
            var repo = new JokesRepository(_connectionString);
            var userLikedStatus = repo.GetStatus(jokeId, user.Id);
            if (userLikedStatus == null)
            {
                return "";
            }
            else if (userLikedStatus.Status == Status.Liked)
            {
                return "liked";
            }
            return "disliked";
        }
        [HttpPost]
        [Route("updatestatus")]
        public void UpdateStatus(UpdateStatusViewModel vm)
        {
            var userRepo = new UserRepository(_connectionString);
            var user = userRepo.GetByEmail(User.Identity.Name);
            var repo = new JokesRepository(_connectionString);
            repo.UpdateStatus(vm.JokeId, user.Id, vm.Liked);
        }
        [HttpGet]
        [Route("getalljokes")]
        public List<Joke> GetAllJokes()
        {
            var repo = new JokesRepository(_connectionString);
            return repo.GetAllJokes();
        }
    }
}
