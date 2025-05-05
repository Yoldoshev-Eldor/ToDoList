using FluentValidation;
using ToDoList.Service.Dtos;

namespace ToDoList.Service.Validators;

public class ValidatorUpdateDto : AbstractValidator<ToDoItemUpdateDto>
{
    public ValidatorUpdateDto()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("ToDoItemId is required.");
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(100)
            .WithMessage("Title must not exceed 100 characters.");
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(251)
            .WithMessage("Description must not exceed 500 characters.");
        RuleFor(x => x.DueDate)
            .NotEmpty()
            .WithMessage("Due date is required.")
            .GreaterThan(DateTime.Now)
            .WithMessage("Due date must be in the future.");
    }
}
