using System.Text.Json.Serialization;

namespace StytchAuth.Models.Shared;

public record Options(
    [property: JsonPropertyName("ip_match_required")] bool? IPMatchRequired = null,
    [property: JsonPropertyName("user_agent_match_required")] bool? UserAgentMatchRequired = null
);
