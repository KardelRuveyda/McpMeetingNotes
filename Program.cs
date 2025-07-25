
using MeetingMcp.Services;
using MeetingNotesMCP.Tools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);

builder.Services.AddSingleton<MeetingNoteService>();

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<MeetingNoteTools>();

await builder.Build().RunAsync();
