using System.Text.Json.Serialization;

namespace NewNexum.Users.Infrastructure.Identity;

internal record UserRepresentation(
    [property: JsonPropertyName("username")] string UserName,
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("firstName")] string FirstName,
    [property: JsonPropertyName("lastName")] string LastName,
    [property: JsonPropertyName("emailVerified")] bool EmaiVerified,
    [property: JsonPropertyName("enabled")] bool Enabled,
    [property: JsonPropertyName("credentials")] CredentialRepresentation[] Credentials
);