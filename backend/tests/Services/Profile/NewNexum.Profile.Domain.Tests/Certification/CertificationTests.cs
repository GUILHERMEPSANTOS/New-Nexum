using Bogus;
using Bogus.Extensions.UnitedKingdom;
using NewNexum.Core.Communication;
using NewNexum.Core.ValueObjects;

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
            var faker = new Faker();               
            //Act;
            var result = certificate.Update(name: null,
                                            issuingOrganization: null,
                                            dateOfIssue: date,
                                            expirationDate: date.AddDays(-20),
                                            credentialCode: "code",
                                            credentialURL: Url.Create(faker.Internet.Url()).Value);

            //Assert
            Assert.Equal(CertificationErrors.DateOfIssueMustBeEarlierThanExpirationDate, result.Error);
        }
    }
}
