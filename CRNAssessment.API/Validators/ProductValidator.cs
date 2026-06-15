using FluentValidation;
using CRNAssessment.API.Models;

namespace CRNAssessment.API.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty()
            .WithMessage("Product Name is required");

        RuleFor(x => x.CreatedBy)
            .NotEmpty()
            .WithMessage("Created By is required");
    }
}