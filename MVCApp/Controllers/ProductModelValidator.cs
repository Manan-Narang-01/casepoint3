using FluentValidation;
using MVCApp.Models;

public class ProductModelValidator : AbstractValidator<Student>
{
    public ProductModelValidator()
    {
        RuleFor(x => x.c_studname).NotEmpty().WithMessage("name is required");
    }
}