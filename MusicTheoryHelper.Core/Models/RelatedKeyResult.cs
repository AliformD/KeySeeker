namespace MusicTheoryHelper.Core.Models;

public sealed class RelatedKeyResult
{
    public required string RequestedKey { get; init; }
    public required string RelativeKey { get; init; }
    public required IReadOnlyList<string> NeighborKeys { get; init; }
}
