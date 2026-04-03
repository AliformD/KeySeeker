using MusicTheoryHelper.Core.Interfaces;
using MusicTheoryHelper.Core.Models;

namespace MusicTheoryHelper.Core.Services;

public sealed class KeyAnalysisService(IKeyService keyService, IChordService chordService) : IKeyAnalysisService
{
    public AnalysisResult AnalyzeNotes(IReadOnlyCollection<string> inputNotes)
    {
        var input = new HashSet<string>(inputNotes, StringComparer.OrdinalIgnoreCase);
        var keys = keyService.GetAllKeys()
            .Where(k => input.All(n => k.Notes.Contains(n, StringComparer.OrdinalIgnoreCase)))
            .Select(k => k.Name)
            .ToList();

        var chords = chordService.FindMatchingChords(inputNotes);

        return new AnalysisResult
        {
            PossibleKeys = keys,
            PossibleChords = chords
        };
    }
}
