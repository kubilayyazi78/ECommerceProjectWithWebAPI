using Entities.Dtos.Resources;
using FluentValidation;

namespace Business.Validations.FluentValidation
{
    public class ResourceUpdateDtoValidator : AbstractValidator<ResourceUpdateDto>
    {
        public ResourceUpdateDtoValidator()
        {
            RuleFor(x => x.ResourceName).NotEmpty().
                WithErrorCode("VALIDATION_ResourceNameFieldCannotBeEmpty");
        }
    }
}