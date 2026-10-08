using CampusEats.Api.Models;
using CampusEats.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CampusEats.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet]
    [AllowAnonymous]
    public ActionResult<List<MenuItem>> GetAll()
        => Ok(_menuService.GetAll());

    [HttpGet("{id:int}")]
    public ActionResult<MenuItem> GetById(int id)
    {
        var item = _menuService.GetById(id);

        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public ActionResult<MenuItem> Create(MenuItem item)
    {
        var createdItem = _menuService.Create(item);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdItem.Id },
            createdItem
        );
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Update(int id, MenuItem item)
    {
        var updated = _menuService.Update(id, item);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        var deleted = _menuService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
