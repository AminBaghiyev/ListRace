using ListRace.BL.DTOs;
using ListRace.Core.Models;

namespace ListRace.BL.Services.Abstractions;

public interface IPlaceService
{
    Task<ICollection<PlaceViewItemDTO>> GetPlaceViewItemsAsync();
    Task<ICollection<PlaceListItemDTO>> GetPlaceListItemsAsync();
    Task<Place> GetByIdAsync(int id);
    Task<PlaceUpdateDTO> GetByIdForUpdateAsync(int id);
    Task CreateAsync(PlaceCreateDTO dto);
    Task UpdateAsync(PlaceUpdateDTO dto);
    Task DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
