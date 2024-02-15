namespace NewNexum.Profile.Api.Contracts
{
    public record RegisterCertificationRequest(
        string? Name,               //Para teste
        string? IssuingOrganization,//Para teste
        DateTime? DateOfIssue,
        DateTime? ExpirationDate,
        string CredentialCode,
        string CredentialURL);
}
