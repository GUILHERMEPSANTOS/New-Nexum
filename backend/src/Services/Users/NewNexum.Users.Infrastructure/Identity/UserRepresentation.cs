namespace NewNexum.Users.Infrastructure.Identity;

internal record UserRepresentation(
    string UserName,
    string Email,
    string FirstName,
    string LastName,
    bool EmaiVerified,
    bool Enabled,
    CredentialRepresentation[] Credentials
 );
