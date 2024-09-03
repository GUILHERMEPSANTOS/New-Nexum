namespace NewNexum.Users.Domain.User
{
    public class Role
    {
        public string Name { get; set; }

        public static readonly Role Member = new("Member");
        public static readonly Role Admin = new("Admin");

        public Role(string name)
        {
            Name = name;
        }
    }
}
