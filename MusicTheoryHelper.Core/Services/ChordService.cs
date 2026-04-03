using MusicTheoryHelper.Core.Data;
using MusicTheoryHelper.Core.Interfaces;

namespace MusicTheoryHelper.Core.Services;

public sealed class ChordService : IChordService
{
    public IReadOnlyList<string> FindMatchingChords(IReadOnlyCollection<string> inputNotes)
    {
        var normalizedInput = new HashSet<string>(inputNotes, StringComparer.OrdinalIgnoreCase);

        return ChordLibrary.All
            .Where(chord => chord.Notes.All(n => normalizedInput.Contains(n)))
            .Select(chord => chord.Name)
            .ToList();
    }
}
