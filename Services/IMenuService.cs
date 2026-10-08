using CampusEats.Api.Models;

namespace CampusEats.Api.Services;

public interface IMenuService
{
    List<MenuItem> GetAll();

    MenuItem? GetById(int id);

    MenuItem Create(MenuItem item);

    bool Update(int id, MenuItem item);

    bool Delete(int id);
}