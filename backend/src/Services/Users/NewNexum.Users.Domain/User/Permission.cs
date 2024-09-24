namespace NewNexum.Users.Domain.User;

public sealed class Permission
{
    public string Code { get; }
    public static readonly Permission AddCertificationProfile = new("profile-certification:add");
    public static readonly Permission ModifyCertificationProfile = new("profile-certification:update");
    public static readonly Permission RemoveCertificationProfile = new("profile-certification:remove");

    public Permission(string code)
    {
        Code = code;
    }
}
