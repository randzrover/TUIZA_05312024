using FluentValidation;

namespace Application.Items.Command.CreateItem;

public sealed class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
{
    public CreateItemCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).MaximumLength(1000).NotEmpty();
    }
}