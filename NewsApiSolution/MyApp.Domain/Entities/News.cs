namespace MyApp.Domain.Entities;

public class News
{
    public int Id { get; set; }
    public int MenuId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Quan hệ 1-n với Menu
    public Menu? Menu { get; set; }
}
