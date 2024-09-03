using System.Net.Http.Json;


namespace NewNexum.Users.Infrastructure.Identity
{
    internal class KeyCloakClient(HttpClient httpClient)
    {
        internal async Task<string> RegisterUserAsync(
            UserRepresentation user,
            CancellationToken cancellationToken = default)
        {
            var httpResponseMessage = await httpClient.PostAsJsonAsync("users", user, cancellationToken);

            httpResponseMessage.EnsureSuccessStatusCode();

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
