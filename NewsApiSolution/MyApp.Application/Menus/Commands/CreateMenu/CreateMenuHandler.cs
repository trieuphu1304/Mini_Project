using MediatR;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
namespace MyApp.Application.Menus.Commands;

public class CreateMenuHandler : IRequestHandler<CreateMenuCommand, int>
{
    private readonly IAppDbContext _db;
    public CreateMenuHandler(IAppDbContext db) => _db = db;

    public async Task<int> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = new Menu { Title = request.Title, Slug = request.Slug };
        _db.Menus.Add(menu);
        await _db.SaveChangesAsync(cancellationToken);
        return menu.Id;
    }
}
