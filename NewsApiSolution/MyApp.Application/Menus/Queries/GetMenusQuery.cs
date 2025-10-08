using MediatR;
using MyApp.Application.Menus.DTOs;
using MyApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Application.Menus.Queries
{
    public record GetMenusQuery : IRequest<List<MenuDto>>;

    public class GetMenusQueryHandler : IRequestHandler<GetMenusQuery, List<MenuDto>>
    {
        private readonly IAppDbContext _context;

        public GetMenusQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuDto>> Handle(GetMenusQuery request, CancellationToken cancellationToken)
        {
            return await _context.Menus
                .Select(m => new MenuDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Slug = m.Slug
                })
                .ToListAsync(cancellationToken);
        }
    }
}
