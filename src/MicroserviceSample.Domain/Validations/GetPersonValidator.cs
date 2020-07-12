using FluentValidation;
using MicroserviceSample.Domain.Commands;

namespace MicroserviceSample.Domain.Validations
{
    public class GetPersonValidator : AbstractValidator<GetPersonCommand>
    {
        public GetPersonValidator()
        {
            RuleFor(person => person.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}