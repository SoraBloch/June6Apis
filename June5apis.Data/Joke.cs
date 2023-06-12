using System.Text.Json.Serialization;

namespace June5apis.Data
{
    public class Joke
    {
        public int Id { get; set; }
        public int OriginId { get; set; }
        public string Setup { get; set; }
        public string Punchline { get; set; }
        public List<UserLikedJoke> UserLikedJokes { get; set; }
    }    
}