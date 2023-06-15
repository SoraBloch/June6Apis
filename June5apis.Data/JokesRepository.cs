using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June5apis.Data
{
    public class JokesRepository
    {
        private readonly string _connectionString;

        public JokesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddJoke(Joke j)
        {
            using var context = new JokesDataContext(_connectionString);
            var jokeExists = context.Jokes.FirstOrDefault(joke => joke.OriginId == j.OriginId);
            if (jokeExists == null)
            {
                context.Jokes.Add(j);
                context.SaveChanges();
            }
        }
        public Joke GetJokeWithLikes(int jokeId)
        {
            using var context = new JokesDataContext(_connectionString);
            return context.Jokes.Include(u => u.UserLikedJokes)
                .FirstOrDefault(j => j.Id == jokeId);
        }
        public Joke GetJokeByOriginId(int originId)
        {
            var context = new JokesDataContext(_connectionString);
            return context.Jokes.FirstOrDefault(j => j.OriginId == originId);
        }
        public UserLikedJoke GetStatus(int jokeId, int userId)
        {
            var context = new JokesDataContext(_connectionString);
            return context.UserLikedJokes.FirstOrDefault(j => j.JokeId == jokeId && j.UserId == userId);
        }
        public void UpdateStatus(int jokeId, int userId, bool like)
        {
            Status status = Status.Liked;
            if (!like)
            {
                status = Status.Disliked;
            }
            var context = new JokesDataContext(_connectionString);
            var userLikedJoke = context.UserLikedJokes.FirstOrDefault(j => j.JokeId == jokeId && j.UserId == userId);
            if (userLikedJoke == null)
            {
                context.UserLikedJokes.Add(new UserLikedJoke
                {
                    UserId = userId,
                    JokeId = jokeId,
                    Status = status,
                    DateLiked = DateTime.Now
                });
            }
            else
            {
                userLikedJoke.Status = status;
                userLikedJoke.DateLiked = DateTime.Now;
            }

            context.SaveChanges();
        }
        public List<Joke> GetAllJokes()
        {
            var context = new JokesDataContext(_connectionString);
            return context.Jokes.Include(j => j.UserLikedJokes).ToList();
        }
    }
}
