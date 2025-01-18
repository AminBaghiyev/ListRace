using FluentValidation;

namespace ListRace.BL.DTOs;

public record CategoryUpdateDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
}

public class CategoryUpdateDTOValidation : AbstractValidator<CategoryUpdateDTO>
{
    public CategoryUpdateDTOValidation()
    {
        RuleFor(e => e.Id)
            .GreaterThan(0).WithMessage("Id must be a natural number!");

        RuleFor(e => e.Title)
            .NotEmpty().WithMessage("Title cannot be empty!")
            .MinimumLength(5).WithMessage("Title must be at least 5 symbols long!")
            .MaximumLength(50).WithMessage("The length of the title cannot exceed 50 symbols!");
    }
}