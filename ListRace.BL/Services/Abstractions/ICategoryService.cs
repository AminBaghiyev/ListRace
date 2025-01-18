using ListRace.BL.DTOs;
using ListRace.Core.Models;

namespace ListRace.BL.Services.Abstractions;

public interface ICategoryService
{
    Task<ICollection<CategoryViewItemDTO>> GetCategoryViewItemsAsync();
    Task<ICollection<CategoryListItemDTO>> GetCategoryListItemsAsync();
    Task<Category> GetByIdAsync(int id);
    Task<Category> GetByIdWithChildrenAsync(int id);
    Task<CategoryUpdateDTO> GetByIdForUpdateAsync(int id);
    Task CreateAsync(CategoryCreateDTO dto);
    Task UpdateAsync(CategoryUpdateDTO dto);
    Task DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
