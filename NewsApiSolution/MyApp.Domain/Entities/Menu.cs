namespace MyApp.Domain.Entities;

public class Menu
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;

    // Quan hệ 1-n
    public ICollection<News> NewsItems { get; set; } = new List<News>();
}
