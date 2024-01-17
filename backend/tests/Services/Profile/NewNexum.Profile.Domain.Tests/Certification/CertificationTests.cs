using NewNexum.Core.Communication;

namespace NewNexum.Profile.Domain.CertificationTests
{
    public class CertificationTests
    {
        [Fact(DisplayName = "Deve Retornar um novo Certificado")]
        [Trait("Category", "Certification")]
        public void GivenNewCertificate_WhenAddingNewValidCertificate_ShouldSucceed()
        {
            // Arrange & Act
            var certificate = Certification.Create(name: "Introdução ao Java", issuingOrganization: "Alura", userId: "userId");

            //Assert
            Assert.NotNull(certificate);
            Assert.Contains("Introdução ao Java", certificate.Name);
            Assert.Contains("Alura", certificate.IssuingOrganization);
            Assert.Contains("userId", certificate.UserId);
            Assert.Null(certificate.CredentialURL);
            Assert.Null(certificate.DateAdded);
            Assert.Null(certificate.DateOfIssue);
            Assert.Null(certificate.ExpirationDate);
        }

        [Fact(DisplayName = "Deve Retornar um novo Certificado")]
        [Trait("Category", "Certification")]
        public void GivenOldCertificate_WhenUpdateCertificate_ShouldSucceed()
        {
            // Arrange 
            var certificate = Certification.Create(name: "Introdução ao Java", issuingOrganization: "Alura", userId: "userId");
            var date = DateTime.UtcNow;

            //Assert &&  Act
            Assert.Throws<Exception>(
                () => certificate.Update(
                        name: null,
                        issuingOrganization: null,
                        dateOfIssue: date,
                        expirationDate: date,
                        credentialCode: "code",
                        credentialURL: "Teste dev.io"));
        }
    }
}
