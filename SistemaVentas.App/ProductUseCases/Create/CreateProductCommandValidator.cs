using FluentValidation;

namespace SistemaVentas.App.ProductUseCases.Create
{
    public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
    {
        const string messageRequired = "Este campo es requerido";
        const string messageEmpty = "Este campo no puede ser vacío";
        public CreateProductCommandValidator()
        {
            RuleFor(producto => producto.Name)
                .NotEmpty().WithMessage(messageEmpty)
                .NotNull().WithMessage(messageRequired);

            RuleFor(producto => producto.Price)
                .NotEmpty().WithMessage(messageEmpty)
                .NotNull().WithMessage(messageRequired);

            RuleFor(producto => producto.Stock)
                .NotEmpty().WithMessage(messageEmpty)
                .NotNull().WithMessage(messageRequired);

            RuleFor(producto => producto.CategoryId)
                .NotEmpty().WithMessage(messageEmpty)
                .NotNull().WithMessage(messageRequired);
        }
    }
}
