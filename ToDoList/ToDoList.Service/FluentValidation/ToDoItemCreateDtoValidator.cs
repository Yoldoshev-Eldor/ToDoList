using FluentValidation;
using ToDoList.Service.DTOs;

namespace ToDoList.Service.FluentValidation;

public class ToDoItemCreateDtoValidator : AbstractValidator<ToDoItemCreateDto>
{
    public ToDoItemCreateDtoValidator()
    {
        RuleFor(t => t.Title).
            MaximumLength(50).
            NotEmpty().
            WithMessage("Title is required");

        RuleFor(t => t.Description).
            MaximumLength(255).
            NotEmpty().
            WithMessage("Description is required");

        RuleFor(t => t.DueDate).
            NotEmpty().
            NotNull().
            WithMessage("DueDate is required");
    }
}
