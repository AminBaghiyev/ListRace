using AutoMapper;
using ListRace.BL.DTOs;
using ListRace.BL.Exceptions;
using ListRace.BL.Services.Abstractions;
using ListRace.Core.Models;
using ListRace.DL.Repository.Abstractions;

namespace ListRace.BL.Services.Concretes;

public class CategoryService : ICategoryService
{
    readonly IRepository<Category> _repository;
    readonly IMapper _mapper;

    public CategoryService(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Category> GetByIdAsync(int id) => await _repository.GetByIdAsync(id) ?? throw new BaseException();

    public async Task<Category> GetByIdWithChildrenAsync(int id) => await _repository.GetByIdAsync(id, "Places") ?? throw new BaseException();

    public async Task<CategoryUpdateDTO> GetByIdForUpdateAsync(int id) => _mapper.Map<CategoryUpdateDTO>(await GetByIdAsync(id));

    public async Task<ICollection<CategoryListItemDTO>> GetCategoryListItemsAsync() => _mapper.Map<ICollection<CategoryListItemDTO>>(await _repository.GetAllAsync());

    public async Task<ICollection<CategoryViewItemDTO>> GetCategoryViewItemsAsync() => _mapper.Map<ICollection<CategoryViewItemDTO>>(await _repository.GetAllAsync("Places"));

    public async Task CreateAsync(CategoryCreateDTO dto)
    {
        Category category = _mapper.Map<Category>(dto);

        await _repository.CreateAsync(category);
    }

    public async Task UpdateAsync(CategoryUpdateDTO dto)
    {
        Category oldCategory = await GetByIdAsync(dto.Id);
        Category category = _mapper.Map<Category>(dto);
        category.CreatedAt = oldCategory.CreatedAt;

        _repository.Update(category);
    }

    public async Task DeleteAsync(int id)
    {
        Category category = await GetByIdWithChildrenAsync(id);

        if (category.Places.Count != 0) throw new BaseException("This category has places!");

        _repository.Delete(category);
    }

    public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
}
