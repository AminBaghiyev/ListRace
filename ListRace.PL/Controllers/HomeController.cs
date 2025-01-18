using ListRace.BL.Services.Abstractions;
using ListRace.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ListRace.PL.Controllers;

public class HomeController : Controller
{
    readonly ICategoryService _categoryService;
    readonly IPlaceService _placeService;

    public HomeController(ICategoryService categoryService, IPlaceService placeService)
    {
        _categoryService = categoryService;
        _placeService = placeService;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            HomeVM VM = new()
            {
                Categories = await _categoryService.GetCategoryViewItemsAsync(),
                Places = await _placeService.GetPlaceViewItemsAsync()
            };

            return View(VM);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }
}
