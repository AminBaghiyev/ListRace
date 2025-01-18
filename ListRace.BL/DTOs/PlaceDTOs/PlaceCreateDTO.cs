using FluentValidation;
using ListRace.BL.Utilities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ListRace.BL.DTOs;

public record PlaceCreateDTO
{
    public IFormFile Image { get; set; }
    public string Title { get; set; }

    [Display(Name = "Minimum price")]
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
    public decimal Rating { get; set; }
    public int RatingCount { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public bool IsActive { get; set; }
}

public class PlaceCreateDTOValidation : AbstractValidator<PlaceCreateDTO>
{
    public PlaceCreateDTOValidation()
    {
        RuleFor(e => e.Title)
            .NotEmpty().WithMessage("Title cannot be empty!")
            .MinimumLength(10).WithMessage("Title must be at least 10 symbols long!")
            .MaximumLength(100).WithMessage("The length of the title cannot exceed 100 symbols!");

        RuleFor(e => e.Description)
            .NotEmpty().WithMessage("Description cannot be empty!")
            .MinimumLength(10).WithMessage("Description must be at least 10 symbols long!")
            .MaximumLength(255).WithMessage("The length of the description cannot exceed 255 symbols!");

        RuleFor(e => e.CategoryId)
            .NotEmpty().WithMessage("Category id cannot be empty!")
            .GreaterThan(0).WithMessage("Category id must be a natural number!");

        RuleFor(e => e.MinPrice)
            .NotEmpty().WithMessage("Minimum price cannot be empty!")
            .GreaterThanOrEqualTo(0).WithMessage("Minimum price must be 0 or greater!")
            .LessThanOrEqualTo(99999999.99m).WithMessage("Minimum price must be 99999999.99 or less than that!");

        RuleFor(e => e.MaxPrice)
            .NotEmpty().WithMessage("Maximum price cannot be empty!")
            .GreaterThanOrEqualTo(0).WithMessage("Maximum price must be 0 or greater!")
            .LessThanOrEqualTo(99999999.99m).WithMessage("Maximum price must be 99999999.99 or less than that!");

        RuleFor(e => e.Rating)
            .NotEmpty().WithMessage("Rating cannot be empty!")
            .GreaterThanOrEqualTo(0).WithMessage("Rating must be 0 or greater!")
            .LessThanOrEqualTo(5).WithMessage("Rating must be 5 or less than that!");

        RuleFor(e => e.RatingCount)
            .NotEmpty().WithMessage("Rating count cannot be empty!")
            .GreaterThanOrEqualTo(0).WithMessage("Rating count must be 0 or greater!");

        RuleFor(x => x.Image)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Image cannot be null!")
            .Must(x => x.Length <= 2 * 1024 * 1024).WithMessage("File size must be less than 2 MB!")
            .Must(x => x.CheckType("image")).WithMessage("File must be image!");
    }
}