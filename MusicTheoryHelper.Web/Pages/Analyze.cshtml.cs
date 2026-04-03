using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicTheoryHelper.Core.Interfaces;
using MusicTheoryHelper.Core.Models;

namespace MusicTheoryHelper.Web.Pages;

public sealed class AnalyzeModel(INoteParserService parser, IKeyAnalysisService analysisService) : PageModel
{
    [BindProperty]
    public string InputNotes { get; set; } = string.Empty;

    public AnalysisResult? Result { get; private set; }
    public string? ErrorMessage { get; private set; }

    public void OnPost()
    {
        try
        {
            var notes = parser.ParseNotes(InputNotes);
            Result = analysisService.AnalyzeNotes(notes);
        }
        catch (ArgumentException ex)
        {
            ErrorMessage = ex.Message;
        }
    }
}
