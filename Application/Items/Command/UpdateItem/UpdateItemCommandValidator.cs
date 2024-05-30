using FluentValidation;

namespace Application.Items.Command.UpdateItem;
public sealed class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommand>
{
    public UpdateItemCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
