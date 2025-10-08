using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;

namespace MyApp.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Menu> Menus { get; }
        DbSet<News> News { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
