using MusicTheoryHelper.Core.Interfaces;
using MusicTheoryHelper.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<INoteParserService, NoteParserService>();
builder.Services.AddSingleton<IKeyService, KeyService>();
builder.Services.AddSingleton<IChordService, ChordService>();
builder.Services.AddSingleton<IKeyAnalysisService, KeyAnalysisService>();
builder.Services.AddSingleton<IRelatedKeyService, RelatedKeyService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();
