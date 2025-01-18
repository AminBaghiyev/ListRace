using FluentValidation;
using ListRace.BL.Utilities;
using Microsoft.AspNetCore.Http;

namespace ListRace.BL.DTOs;

public record PlaceUpdateDTO
{
    public int Id { get; set; }
    public string ImageURL { get; set; }
    public IFormFile? Image { get; set; }
    public string Title { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
    public decimal Rating { get; set; }
    public int RatingCount { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public bool IsActive { get; set; }
}

public class PlaceUpdateDTOValidation : AbstractValidator<PlaceUpdateDTO>
{
    public PlaceUpdateDTOValidation()
    {
        RuleFor(e => e.Id)
            .GreaterThan(0).WithMessage("Id must be a natural number!");

        RuleFor(e => e.Title)
            .NotEmpty().WithMessage("Title cannot be empty!")
            .MinimumLength(10).WithMessage("Title must be at least 10 symbols long!")
            .MaximumLength(100).WithMessage("The length of the title cannot exceed 100 symbols!");

        RuleFor(e => e.Description)
            .NotEmpty().WithMessage("Description cannot be empty!")
            .MinimumLength(10).WithMessage("Description must be at least 10 symbols long!")
            .MaximumLength(255).WithMessage("The length of the description cannot exceed 255 symbols!");

        RuleFor(e => e.CategoryId)
            .GreaterThan(0).WithMessage("Category id must be a natural number!");

        RuleFor(e => e.MinPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Minimum price must be 0 or greater!")
            .LessThanOrEqualTo(99999999.99m).WithMessage("Minimum price must be 99999999.99 or less than that!");

        RuleFor(e => e.MaxPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Maximum price must be 0 or greater!")
            .LessThanOrEqualTo(99999999.99m).WithMessage("Maximum price must be 99999999.99 or less than that!");

        RuleFor(e => e.Rating)
            .GreaterThanOrEqualTo(0).WithMessage("Rating must be 0 or greater!")
            .LessThanOrEqualTo(5).WithMessage("Rating must be 5 or less than that!");

        RuleFor(e => e.RatingCount)
            .GreaterThanOrEqualTo(0).WithMessage("Rating count must be 0 or greater!");

        RuleFor(x => x.Image)
            .Must(x => x is null || x.Length <= 2 * 1024 * 1024).WithMessage("File size must be less than 2 MB!")
            .Must(x => x is null || x.CheckType("image")).WithMessage("File must be image!");
    }
}