namespace MeetingMcp.Models;

public class MeetingNote {
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
