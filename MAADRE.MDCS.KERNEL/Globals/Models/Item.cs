﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.Globals.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
    }

    public class ItemImages
    {
        public string Id { get; set; } = string.Empty;
        public string Src { get; set; }
    }

    public class UserCredentials
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool returnSecureToken { get; set; } = true;
    }

    public class SignUpUserCredentialsResponse
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("idToken")]
        public string IdToken { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("expiresIn")]
        public string ExpiresIn { get; set; }

        [JsonPropertyName("localId")]
        public string LocalId { get; set; }
    }
    /****/


}
