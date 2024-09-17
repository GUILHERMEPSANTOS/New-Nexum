using Moq;
using Moq.Protected;
using NewNexum.Infra.IdP.Keycloak;
using NewNexum.Users.Infrastructure.Identity;
using System.Security.Cryptography.Xml;

namespace NewNexum.infra.Idp.Tests.KeyCloak
{
    public class KeyCloakClientTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandler;
        private readonly HttpClient _httpClient;
        private readonly KeyCloakClient _keyCloakClient;

        public KeyCloakClientTests()
        {
            _httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            _httpClient = new HttpClient(_httpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://fake-keycloak-api.com")
            };

            _keyCloakClient = new KeyCloakClient(_httpClient);
        }

        [Fact(DisplayName = "when Keycloak registration failure")]
        [Trait("IDP", "keycloak")]
        public async Task RegisterUserAsync_ShouldReturnFailure_WhenRegistrationFails()
        {
            // Arrange
            var user = new UserRepresentation(
                "userName",
                "Email",
                "FirstName",
                "LastName",
                true,
                true,
                [new CredentialRepresentation("Type", "Value", false)]
             );

            _httpMessageHandler
                 .Protected()
                 .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                 .ReturnsAsync(new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.BadRequest });
           
            //Act
            var result = await _keyCloakClient.RegisterUserAsync(user, default);

            //Asset
            Assert.True(result.IsFailure);
            Assert.Equal(KeycloakErros.FailureRegisterUser, result.Error);
        }
    }
}
