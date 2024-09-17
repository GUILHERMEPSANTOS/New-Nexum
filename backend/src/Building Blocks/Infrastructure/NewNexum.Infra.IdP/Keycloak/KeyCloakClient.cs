using NewNexum.Core.Communication;
using NewNexum.Infra.IdP.Keycloak;
using System.Net.Http.Json;
using System.Text.Json;


namespace NewNexum.Users.Infrastructure.Identity
{
    public class KeyCloakClient(HttpClient httpClient)
    {
        public async Task<Result<string>> RegisterUserAsync(
            UserRepresentation user,
            CancellationToken cancellationToken = default)
        {
            var httpResponseMessage = await httpClient.PostAsJsonAsync("users", user, cancellationToken);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
               return Result.Failure<string>(KeycloakErros.FailureRegisterUser);
            }

            return ExtractIdentityIdFromLocationHeader(httpResponseMessage);
        }

        private static string ExtractIdentityIdFromLocationHeader(HttpResponseMessage httpResponseMessage)
        {
            const string usersSegmentName = "users/";

            var locationHeader = httpResponseMessage.Headers.Location?.PathAndQuery;

            if (locationHeader is null)
                throw new ArgumentNullException("Location header is null");

            var userSegmentValueIndex = locationHeader.IndexOf(usersSegmentName, StringComparison.InvariantCultureIgnoreCase);

            var identityId = locationHeader[(userSegmentValueIndex + usersSegmentName.Length)..];

            return identityId;
        }
    }
}
