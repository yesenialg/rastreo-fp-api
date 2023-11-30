using FluentValidation;

namespace RastreoFirplak.Application.Features.Guias.Commands.UpdateGuia
{
    public class UpdateGuiaCommandValidator : AbstractValidator<UpdateGuiaCommand>
    {
        public UpdateGuiaCommandValidator() 
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{Nombre no puede estar el blanco}")
                .NotNull();

        }
    }
}
