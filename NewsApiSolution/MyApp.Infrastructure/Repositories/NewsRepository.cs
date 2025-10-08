using Microsoft.EntityFrameworkCore;
using MyApp.Application.Interfaces.Repositories;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Persistence;

namespace MyApp.Infrastructure.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly AppDbContext _context;

        public NewsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<News>> GetAllAsync()
        {
            return await _context.News.Include(n => n.Menu).ToListAsync();
        }

        public async Task<News?> GetByIdAsync(int id)
        {
            return await _context.News.Include(n => n.Menu)
                                      .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task AddAsync(News news)
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(News news)
        {
            _context.News.Update(news);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.News.FindAsync(id);
            if (entity != null)
            {
                _context.News.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
