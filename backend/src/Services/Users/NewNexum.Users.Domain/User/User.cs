using NewNexum.Core.Communication;

namespace NewNexum.Users.Domain.User;

public class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string IdentityId { get; private set; }
    public IReadOnlyCollection<Role> Roles => _roles;
    private readonly List<Role> _roles = [];

    private User(
        string email,
        string firstName,
        string lastName,
        string identityId)
    {
        Id = Guid.NewGuid();
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        IdentityId = identityId;
    }

    public static Result<User> Create(
        string email,
        string firstName,
        string lastName,
        string identityId)
    {
        var user = new User(email, firstName, lastName, identityId);

        user._roles.Add(Role.Member);

        return user;
    }
}
