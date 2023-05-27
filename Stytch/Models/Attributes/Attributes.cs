using System.Text.Json.Serialization;

namespace Stytch.Models;

public record Attributes(
    [property: JsonPropertyName("ip_address")] string? IpAddress = null,
    [property: JsonPropertyName("user_agent")] string? UserAgent = null
);
