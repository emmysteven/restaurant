namespace Restaurant.Application.Settings;

public class JWTSettings
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Subject { get; set; }
    public double DurationInMinutes { get; set; }
}