using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Application.Interfaces;
using MyApp.Application.Interfaces.Repositories;
using MyApp.Application.Menus.DTOs;
using MyApp.Domain.Entities;

namespace MyApp.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<MenuDto>> GetAllMenusAsync()
        {
            var menus = await _menuRepository.GetAllAsync();
            return menus.Select(m => new MenuDto
            {
                Id = m.Id,
                Title = m.Title,
                Slug = m.Slug
            });
        }

        public async Task<MenuDto> GetMenuByIdAsync(int id)
        {
            var menu = await _menuRepository.GetByIdAsync(id);
            if (menu == null) return null;

            return new MenuDto
            {
                Id = menu.Id,
                Title = menu.Title,
                Slug = menu.Slug
            };
        }

        public async Task CreateMenuAsync(MenuDto menuDto)
        {
            var menu = new Menu
            {
                Title = menuDto.Title,
                Slug = menuDto.Slug
            };

            await _menuRepository.AddAsync(menu);
        }

        public async Task UpdateMenuAsync(MenuDto menuDto)
        {
            var existingMenu = await _menuRepository.GetByIdAsync(menuDto.Id);
            if (existingMenu == null) return;

            existingMenu.Title = menuDto.Title;
            existingMenu.Slug = menuDto.Slug;

            await _menuRepository.UpdateAsync(existingMenu);
        }

        public async Task DeleteMenuAsync(int id)
        {
            var menu = await _menuRepository.GetByIdAsync(id);
            if (menu != null)
            {
                await _menuRepository.DeleteAsync(menu.Id);
            }
        }
    }
}
