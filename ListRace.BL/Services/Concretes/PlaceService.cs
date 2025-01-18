using AutoMapper;
using ListRace.BL.DTOs;
using ListRace.BL.Exceptions;
using ListRace.BL.Services.Abstractions;
using ListRace.BL.Utilities;
using ListRace.Core.Models;
using ListRace.DL.Repository.Abstractions;

namespace ListRace.BL.Services.Concretes;

public class PlaceService : IPlaceService
{
    readonly IRepository<Place> _repository;
    readonly IRepository<Category> _categoryRepository;
    readonly IMapper _mapper;

    public PlaceService(IRepository<Place> repository, IMapper mapper, IRepository<Category> categoryRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<Place> GetByIdAsync(int id) => await _repository.GetByIdAsync(id, "Category") ?? throw new BaseException();

    public async Task<PlaceUpdateDTO> GetByIdForUpdateAsync(int id) => _mapper.Map<PlaceUpdateDTO>(await GetByIdAsync(id));

    public async Task<ICollection<PlaceListItemDTO>> GetPlaceListItemsAsync() => _mapper.Map<ICollection<PlaceListItemDTO>>(await _repository.GetAllAsync("Category"));

    public async Task<ICollection<PlaceViewItemDTO>> GetPlaceViewItemsAsync() => _mapper.Map<ICollection<PlaceViewItemDTO>>(await _repository.GetAllAsync("Category"));

    public async Task CreateAsync(PlaceCreateDTO dto)
    {
        if (await _categoryRepository.GetByIdAsync(dto.CategoryId) is null) throw new BaseException("Category not found!");

        Place place = _mapper.Map<Place>(dto);

        place.ImageURL = await dto.Image.SaveAsync("places");

        await _repository.CreateAsync(place);
    }

    public async Task UpdateAsync(PlaceUpdateDTO dto)
    {
        if (await _categoryRepository.GetByIdAsync(dto.CategoryId) is null) throw new BaseException("Category not found!");

        Place oldPlace = await GetByIdAsync(dto.Id);
        Place place = _mapper.Map<Place>(dto);
        place.CreatedAt = oldPlace.CreatedAt;

        place.ImageURL = dto.Image is not null ? await dto.Image.SaveAsync("places") : oldPlace.ImageURL;

        _repository.Update(place);

        if (dto.Image is not null) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "places", oldPlace.ImageURL));
    }

    public async Task DeleteAsync(int id)
    {
        Place place = await GetByIdAsync(id);

        _repository.Delete(place);

        File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "places", place.ImageURL));
    }

    public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
}
