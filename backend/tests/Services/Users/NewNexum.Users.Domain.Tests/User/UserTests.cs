using NewNexum.Users.Domain.User;

namespace NewNexum.Users.Domain.Tests.Users
{
    public class UserTests
    {
        [Fact]
        [Trait("Users", "User")]
        public void Create_ShouldAssignMemberRole_WhenUserIsCreated()
        {
            // Arrange & Act
            var user = User.User.Create("nome", "firstName", "lastName", Guid.NewGuid().ToString());
            
            //Assert
            Assert.Contains(Role.Member, user.Value.Roles);         
        }  
    }
}
