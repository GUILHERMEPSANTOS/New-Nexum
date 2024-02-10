using Bogus;
using Bogus.DataSets;
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
            Assert.Null(certificate.Url);
            Assert.NotNull(certificate.DateAdded);
            Assert.NotNull(certificate.UpdateDate);
            Assert.Null(certificate.DateOfIssue);
            Assert.Null(certificate.ExpirationDate);
        }

        [Fact(DisplayName = "Deve Retornar um erro: Date of issue must be earlier than the expiration date.")]
        [Trait("Category", "Certification")]
        public void GivenOldCertificate_WhenUpdateCertificate_ShouldFailure()
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

        [Fact(DisplayName = "Deve Retornar um novo Certificado Atualizado")]
        [Trait("Category", "Certification")]
        public void WhenUpdatingValidCertificate_ShouldReflectChanges()
        {
            // Arrange 
            var certificate = Certification.Create(name: "Introdução ao Java", issuingOrganization: "Alura", userId: "userId");
            var certificateDateAdded = certificate.DateAdded;
            var certificateUpdateDate = certificate.UpdateDate;
            var date = DateTime.UtcNow;
            var name = "C# DDD";
            var issuingOrganization = "Udemy";
            var faker = new Faker();

            //Act;
            var result = certificate.Update(name: name,
                                            issuingOrganization: issuingOrganization,
                                            dateOfIssue: date,
                                            expirationDate: date.AddDays(20),
                                            credentialCode: "code",
                                            credentialURL: Url.Create(faker.Internet.Url()).Value);

            //Assert
            Assert.Equal(false, result.IsFailure);
            Assert.Equal(true, result.IsSuccess);
            Assert.Equal(name, certificate.Name);
            Assert.Equal(issuingOrganization, certificate.IssuingOrganization);
            Assert.True(certificateDateAdded == certificate.DateAdded);
            Assert.True(certificateUpdateDate < certificate.UpdateDate);
        }
    }
}
