using NewNexum.Profile.Domain;

namespace NewNexum.Profile.Domain.CertificationTests
{
    public class CertificationTests
    {
        [Fact(DisplayName = "Deve Retornar um novo Certificado")]
        [Trait("Category", "Certification")]
        public void GivenNewCertificate_WhenAddingNewValidCertificate_ShouldSucceed()
        {
            // Arrange & Act
            var certificate = Certification.Create(name: "Introdução ao Java", issuingOrganization: "Alura", userId: "uifjigj");
            
            //Assert
            Assert.NotNull(certificate);
        }
    }
}
