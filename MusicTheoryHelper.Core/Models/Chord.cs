namespace MusicTheoryHelper.Core.Models;

public sealed class Chord
{
    public required string Name { get; init; }
    public required IReadOnlyList<string> Notes { get; init; }
    public required string ChordType { get; init; }
}
