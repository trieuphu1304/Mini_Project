namespace MyApp.Application.Menus.DTOs;

public class MenuDto
{
    public int Id { get; set; }  
    public string Title { get; set; } = default!;
    public string Slug { get; set; } = default!;
}