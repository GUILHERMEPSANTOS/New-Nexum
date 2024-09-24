using NewNexum.Users.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Users.Domain.Tests.User
{
    public class PermissionTests
    {   
        [Fact]
        [Trait("Permission", "Permission")]
        public void Create_ShouldAddPermissionProfileCertificationAdd_WhenCreatedWithHisType()
        {
            // Arrange & Act
            var permission = Permission.AddCertificationProfile;

            //Assert 
            Assert.Equal("profile-certification:add", permission.Code);
        }
    }
}
