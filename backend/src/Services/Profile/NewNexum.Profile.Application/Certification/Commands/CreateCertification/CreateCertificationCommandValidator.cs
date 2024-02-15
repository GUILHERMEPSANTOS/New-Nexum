using FluentValidation;
using NewNexum.Profile.Domain;
using NewNexum.Application.Core.Extensions;

namespace NewNexum.Profile.Application.Certification.Commands.CreateCertification
{
    internal sealed class CreateCertificationCommandValidator : AbstractValidator<CreateCertificationCommand>
    {
        public CreateCertificationCommandValidator()
        {
            RuleFor(certification =>  certification.Name)
                .NotEmpty()
                .WithError(CertificationErrors.NameCanNotBeEmpty);

            RuleFor(certification => certification.IssuingOrganization)
                .NotEmpty()
                .WithError(CertificationErrors.IssuingOrganizationCanNotBeEmpty);
        }
    }
}
