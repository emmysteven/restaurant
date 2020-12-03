using System;
using System.Text.Json.Serialization;
using Domain.Enums;

namespace Application.DTOs.Account
{
    public class AuthResponse
    {
        public string Token { get; set; }
        [JsonIgnore] public string RefreshToken { get; set; }
    }
}