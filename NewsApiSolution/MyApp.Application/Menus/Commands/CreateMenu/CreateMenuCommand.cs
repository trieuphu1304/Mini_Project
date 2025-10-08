using MediatR;
namespace MyApp.Application.Menus.Commands;

public record CreateMenuCommand(string Title, string? Slug) : IRequest<int>;
