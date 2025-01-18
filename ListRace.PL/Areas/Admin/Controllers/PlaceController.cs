using ListRace.BL.DTOs;
using ListRace.BL.Exceptions;
using ListRace.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ListRace.PL.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class PlaceController : Controller
{
    readonly IPlaceService _service;
    readonly ICategoryService _categoryService;

    public PlaceController(IPlaceService service, ICategoryService categoryService)
    {
        _service = service;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            IEnumerable<PlaceListItemDTO> list = await _service.GetPlaceListItemsAsync();

            return View(list);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }

    public async Task<IActionResult> Create()
    {
        try
        {
            ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryListItemsAsync(), "Id", "Title");
            return View();
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PlaceCreateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryListItemsAsync(), "Id", "Title");
            return View(dto);
        }

        try
        {
            await _service.CreateAsync(dto);
            await _service.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryListItemsAsync(), "Id", "Title");
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
        catch (Exception)
        {
            ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryListItemsAsync(), "Id", "Title");
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }
    }

    public async Task<IActionResult> Update(int id)
    {
        try
        {
            ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryListItemsAsync(), "Id", "Title");
            return View(await _service.GetByIdForUpdateAsync(id));
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(PlaceUpdateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryListItemsAsync(), "Id", "Title");
            return View(dto);
        }

        try
        {
            await _service.UpdateAsync(dto);
            await _service.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryListItemsAsync(), "Id", "Title");
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
        catch (Exception)
        {
            ViewData["Categories"] = new SelectList(await _categoryService.GetCategoryListItemsAsync(), "Id", "Title");
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteAsync(id);
            await _service.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        try
        {
            return View(await _service.GetByIdAsync(id));
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }
}
