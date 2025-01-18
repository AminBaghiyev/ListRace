using ListRace.Core.Models.Base;

namespace ListRace.Core.Models;

public class Place : BaseEntity
{
    public string ImageURL { get; set; }
    public string Title { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
    public decimal Rating { get; set; }
    public int RatingCount { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public bool IsActive { get; set; }
}