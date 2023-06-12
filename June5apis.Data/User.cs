﻿using System.Text.Json.Serialization;

namespace June5apis.Data
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<UserLikedJoke> UserLikedJokes { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}