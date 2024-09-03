namespace NewNexum.Users.Domain.User;

public class Permission
{
    public string Code { get; private set; }
    public static readonly Permission ModifyCertificationProfile = new Permission("profile-certification:update");
    public static readonly Permission AddCertificationProfile = new Permission("profile-certification:add");
    public static readonly Permission RemoveCertificationProfile = new Permission("profile-certification:remove");

    public Permission(string code)
    {
        Code = code;
    }
}
