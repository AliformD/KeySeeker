namespace MusicTheoryHelper.Core.Models;

public sealed class KeySignature
{
    public required string Name { get; init; }
    public required string Mode { get; init; }
    public required IReadOnlyList<string> Notes { get; init; }
}
