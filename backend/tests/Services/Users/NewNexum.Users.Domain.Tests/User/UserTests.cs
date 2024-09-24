

namespace NewNexum.Users.Domain.Tests.Users
{
    public class UserTests
    {
        [Fact]
        [Trait("Users", "User")]
        public void Create_ShouldAssignMemberRole_WhenUserIsCreated()
        {
            // Arrange & Act
            var user = Domain.User.User.Create("nome", "firstName", "lastName", Guid.NewGuid().ToString());
            
            //Assert
            Assert.Contains(Domain.User.Role.Member, user.Value.Roles);         
        }  
    }
}
