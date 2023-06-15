using System.Text.Json.Serialization;

namespace June5apis.Data
{
   public class UserLikedJoke
    {
        public int UserId { get; set; }
        public int JokeId { get; set; }
        public Status Status { get; set; }
        public DateTime DateLiked { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public Joke Joke { get; set; }
    }

}