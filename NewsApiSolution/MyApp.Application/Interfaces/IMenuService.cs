using MyApp.Application.Menus.DTOs;

namespace MyApp.Application.Interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuDto>> GetAllMenusAsync();
        Task<MenuDto> GetMenuByIdAsync(int id);
        Task CreateMenuAsync(MenuDto menu);
        Task UpdateMenuAsync(MenuDto menu);
        Task DeleteMenuAsync(int id);
    }
}
