namespace NewNexum.Users.Infrastructure.Identity
{
    internal sealed class KeyCloakOptions
    {
        public string TokenUrl { get; set; } = string.Empty;
        public string AdminUrl { get; set; } = string.Empty;
        public string ConfidentialClientId { get; set; } = string.Empty;
        public string ConfidentialClientSecret { get; set; } = string.Empty;
    }
}
