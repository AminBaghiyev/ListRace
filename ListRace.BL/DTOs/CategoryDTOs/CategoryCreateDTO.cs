using FluentValidation;

namespace ListRace.BL.DTOs;

public record CategoryCreateDTO
{
    public string Title { get; set; }
}

public class CategoryCreateDTOValidation : AbstractValidator<CategoryCreateDTO>
{
    public CategoryCreateDTOValidation()
    {
        RuleFor(e => e.Title)
            .NotEmpty().WithMessage("Title cannot be empty!")
            .MinimumLength(5).WithMessage("Title must be at least 5 symbols long!")
            .MaximumLength(50).WithMessage("The length of the title cannot exceed 50 symbols!");
    }
}