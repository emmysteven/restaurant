using System.Text.Json.Serialization;

namespace Restaurant.Application.DTOs.Account;

public class AuthResponse
{
    public string Token { get; set; }
    [JsonIgnore] public string RefreshToken { get; set; }
}