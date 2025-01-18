namespace ListRace.BL.DTOs;

public record PlaceViewItemDTO
{
    public string ImageURL { get; set; }
    public string Title { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
    public decimal Rating { get; set; }
    public int RatingCount { get; set; }
    public string Description { get; set; }
    public string CategoryTitle { get; set; }
    public bool IsActive { get; set; }
}
