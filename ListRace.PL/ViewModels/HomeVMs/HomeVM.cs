using ListRace.BL.DTOs;

namespace ListRace.PL.ViewModels;

public class HomeVM
{
    public ICollection<CategoryViewItemDTO> Categories { get; set; }
    public ICollection<PlaceViewItemDTO> Places { get; set; }
}
