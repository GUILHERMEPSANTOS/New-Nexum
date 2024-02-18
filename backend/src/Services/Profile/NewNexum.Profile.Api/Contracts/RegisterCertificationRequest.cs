namespace NewNexum.Profile.Api.Contracts
{
    public record RegisterCertificationRequest(
        string Name,               
        string IssuingOrganization,
        DateTime? DateOfIssue,
        DateTime? ExpirationDate,
        string CredentialCode,
        string CredentialURL);
}
