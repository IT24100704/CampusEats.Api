using CampusEats.Api.Data;
using CampusEats.Api.Models;

namespace CampusEats.Api.Services;

public class MenuService : IMenuService
{
    private readonly AppDbContext _context;

    public MenuService(AppDbContext context)
    {
        _context = context;
    }

    public List<MenuItem> GetAll()
    {
        return _context.MenuItems.ToList();
    }

    public MenuItem? GetById(int id)
    {
        return _context.MenuItems.FirstOrDefault(item => item.Id == id);
    }

    public MenuItem Create(MenuItem item)
    {
        _context.MenuItems.Add(item);
        _context.SaveChanges();

        return item;
    }

    public bool Update(int id, MenuItem item)
    {
        var existingItem = GetById(id);

        if (existingItem is null)
            return false;

        existingItem.Name = item.Name;
        existingItem.Price = item.Price;
        existingItem.Category = item.Category;
        existingItem.Available = item.Available;

        _context.SaveChanges();

        return true;
    }

    public bool Delete(int id)
    {
        var item = GetById(id);

        if (item is null)
            return false;

        _context.MenuItems.Remove(item);
        _context.SaveChanges();

        return true;
    }
}