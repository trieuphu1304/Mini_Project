using MyApp.Application.Interfaces.Repositories;
using MyApp.Domain.Entities;

namespace MyApp.Application.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<IEnumerable<News>> GetAllAsync()
            => await _newsRepository.GetAllAsync();

        public async Task<News?> GetByIdAsync(int id)
            => await _newsRepository.GetByIdAsync(id);

        public async Task CreateAsync(News news)
            => await _newsRepository.AddAsync(news);

        public async Task UpdateAsync(News news)
            => await _newsRepository.UpdateAsync(news);

        public async Task DeleteAsync(int id)
            => await _newsRepository.DeleteAsync(id);
    }
}
