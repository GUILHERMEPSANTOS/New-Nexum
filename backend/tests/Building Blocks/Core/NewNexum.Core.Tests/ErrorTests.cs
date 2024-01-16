using NewNexum.Core.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Core.Tests
{
    public class ErrorTests
    {
        [Fact(DisplayName = "Error deve ser NotFound Type")]
        [Trait("Category", "Error")]
        public void Error_ShouldReturnNotFoundType_WhenErrorIsNotFoundType()
        {
            // Arrange & Act 
            var error = Error.NotFound("Error.NotFound", "Not Found");

            //Assert
            Assert.Equal(ErrorType.NotFound, error.Type);
            Assert.Equal("Error.NotFound", error.Code);
        }

        [Fact(DisplayName = "Error deve ser Failure Type")]
        [Trait("Category", "Error")]
        public void Error_ShouldReturnFailureType_WhenErrorIsFailureType()
        {
            // Arrange & Act 
            var error = Error.Failure("Error.Failure", "Failure");

            //Assert
            Assert.Equal(ErrorType.Failure, error.Type);
            Assert.Equal("Error.Failure", error.Code);
        }

        [Fact(DisplayName = "Error deve ser Validation Type")]
        [Trait("Category", "Error")]
        public void Error_ShouldReturnValidationType_WhenErrorIsValidationType()
        {
            // Arrange & Act 
            var error = Error.Validation("Error.Validation", "Validation");

            //Assert
            Assert.Equal(ErrorType.Validation, error.Type);
            Assert.Equal("Error.Validation", error.Code);
        }

        [Fact(DisplayName = "Error deve ser Conflict Type")]
        [Trait("Category", "Error")]
        public void Error_ShouldReturnConflictType_WhenErrorIsConflictType()
        {
            // Arrange & Act 
            var error = Error.Conflict("Error.Conflict", "Conflict");

            //Assert
            Assert.Equal(ErrorType.Conflict, error.Type);
            Assert.Equal("Error.Conflict", error.Code);
        }
    }
}
