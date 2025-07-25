using MeetingMcp.Models;
using System.Text.Json;

namespace MeetingMcp.Services;

public class MeetingNoteService
{
    private readonly List<MeetingNote> notes = new();
    private readonly string filePath;

    public MeetingNoteService()
    {
        // 📁 Proje içi "Data" klasörünü kullan
        var dataDirectory = Path.Combine(AppContext.BaseDirectory, "Data");
        Directory.CreateDirectory(dataDirectory); // Klasör yoksa oluştur

        filePath = Path.Combine(dataDirectory, "notes.json");
        Load();
    }

    public Task<List<MeetingNote>> GetAllAsync() => Task.FromResult(notes.ToList());

    public Task<MeetingNote?> GetByIdAsync(string id) =>
        Task.FromResult(notes.FirstOrDefault(x => x.Id == id));

    public Task<MeetingNote?> GetLastAsync() =>
        Task.FromResult(notes.OrderByDescending(x => x.Date).FirstOrDefault());

    public Task<List<MeetingNote>> GetByDateAsync(DateTime date) =>
        Task.FromResult(notes.Where(x => x.Date.Date == date.Date).ToList());

    public Task<MeetingNote> AddAsync(string title, string content, DateTime date)
    {
        var note = new MeetingNote { Title = title, Content = content, Date = date };
        notes.Add(note);
        Save();
        return Task.FromResult(note);
    }

    private void Load()
    {
        if (!File.Exists(filePath)) return;

        try
        {
            var json = File.ReadAllText(filePath);
            var loaded = JsonSerializer.Deserialize<List<MeetingNote>>(json);
            if (loaded != null) notes.AddRange(loaded);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Load error: {ex.Message}");
        }
    }

    private void Save()
    {
        try
        {
            var json = JsonSerializer.Serialize(notes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Save error: {ex.Message}");
        }
    }
}
