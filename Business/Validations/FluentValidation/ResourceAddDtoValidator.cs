using Entities.Dtos.Resources;
using FluentValidation;

namespace Business.Validations.FluentValidation
{
    public class ResourceAddDtoValidator : AbstractValidator<ResourceAddDto>
    {
        public ResourceAddDtoValidator()
        {
            RuleFor(x => x.ResourceName).NotEmpty().
                WithErrorCode("VALIDATION_ResourceNameFieldCannotBeEmpty");
        }
    }
}