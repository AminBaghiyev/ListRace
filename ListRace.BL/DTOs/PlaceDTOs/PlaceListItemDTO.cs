namespace ListRace.BL.DTOs;

public record PlaceListItemDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string CategoryTitle { get; set; }
    public bool IsActive { get; set; }
}
