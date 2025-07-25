using MeetingMcp.Models;
using MeetingMcp.Services;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace MeetingNotesMCP.Tools;

[McpServerToolType]
public class MeetingNoteTools {
    private readonly MeetingNoteService service;

    public MeetingNoteTools(MeetingNoteService service) {
        this.service = service;
    }

    [McpServerTool, Description("Tüm toplantı notlarını getirir.")]
    public async Task<string> GetAllNotes() {
        var notes = await service.GetAllAsync();
        return JsonSerializer.Serialize(notes);
    }

    [McpServerTool, Description("Belirli bir ID ile toplantı notu getirir.")]
    public async Task<string> GetNoteById([Description("Toplantı notu ID’si")] string id) {
        var note = await service.GetByIdAsync(id);
        return JsonSerializer.Serialize(note);
    }

    [McpServerTool, Description("Son toplantı notunu getirir.")]
    public async Task<string> GetLastNote() {
        var note = await service.GetLastAsync();
        return JsonSerializer.Serialize(note);
    }

    [McpServerTool, Description("Belirtilen tarihteki toplantı notlarını getirir.")]
    public async Task<string> GetNotesByDate([Description("Tarih (yyyy-MM-dd formatında)")] DateTime date) {
        var notes = await service.GetByDateAsync(date);
        return JsonSerializer.Serialize(notes);
    }

    [McpServerTool, Description("Yeni bir toplantı notu ekler.")]
    public async Task<string> AddNote(
        [Description("Başlık")] string title,
        [Description("İçerik")] string content,
        [Description("Tarih (yyyy-MM-dd)")] DateTime date) {
        var note = await service.AddAsync(title, content, date);
        return JsonSerializer.Serialize(note);
    }
}