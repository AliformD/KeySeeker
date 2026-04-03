using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicTheoryHelper.Core.Interfaces;
using MusicTheoryHelper.Core.Models;

namespace MusicTheoryHelper.Web.Pages;

public sealed class RelatedKeysModel(IRelatedKeyService relatedKeyService) : PageModel
{
    [BindProperty]
    public string KeyName { get; set; } = string.Empty;

    public RelatedKeyResult? Result { get; private set; }
    public string? ErrorMessage { get; private set; }

    public void OnPost()
    {
        try
        {
            Result = relatedKeyService.GetRelatedKeys(KeyName);
        }
        catch (ArgumentException ex)
        {
            ErrorMessage = ex.Message;
        }
    }
}
