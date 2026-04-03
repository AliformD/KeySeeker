using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicTheoryHelper.Core.Interfaces;

namespace MusicTheoryHelper.Web.Pages;

public sealed class KeyNotesModel(IKeyService keyService) : PageModel
{
    [BindProperty]
    public string KeyName { get; set; } = string.Empty;

    public List<string> Notes { get; private set; } = [];
    public string? ErrorMessage { get; private set; }

    public void OnPost()
    {
        try
        {
            Notes = keyService.GetNotesInKey(KeyName).ToList();
        }
        catch (ArgumentException ex)
        {
            ErrorMessage = ex.Message;
        }
    }
}
