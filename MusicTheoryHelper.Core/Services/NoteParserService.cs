using MusicTheoryHelper.Core.Helpers;
using MusicTheoryHelper.Core.Interfaces;

namespace MusicTheoryHelper.Core.Services;

public sealed class NoteParserService : INoteParserService
{
    public IReadOnlyList<string> ParseNotes(string input)
    {
        var tokens = input.Split([',', ' '], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(NoteNormalizationHelper.Normalize)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        var invalid = tokens.Where(t => !NoteNormalizationHelper.IsValid(t)).ToList();
        if (invalid.Count > 0)
        {
            throw new ArgumentException($"Invalid note(s): {string.Join(", ", invalid)}");
        }

        return tokens;
    }
}
