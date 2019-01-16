using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kai.Core.User
{
    public class UserDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("adress")]
        public string Adreess { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("isadmin")]
        public bool IsAdmin { get; set; }
        [JsonProperty("iscutomer")]
        public bool IsCustomer { get; set; }
    }
}
