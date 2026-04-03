using MusicTheoryHelper.Core.Data;
using MusicTheoryHelper.Core.Interfaces;
using MusicTheoryHelper.Core.Models;

namespace MusicTheoryHelper.Core.Services;

public sealed class RelatedKeyService : IRelatedKeyService
{
    private static readonly IReadOnlyDictionary<string, string> Relatives = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        ["C major"] = "A minor",
        ["A minor"] = "C major",
        ["G major"] = "E minor",
        ["E minor"] = "G major",
        ["D major"] = "B minor",
        ["B minor"] = "D major",
        ["F major"] = "D minor",
        ["D minor"] = "F major"
    };

    public RelatedKeyResult GetRelatedKeys(string keyName)
    {
        if (!Relatives.TryGetValue(keyName.Trim(), out var relative))
        {
            throw new ArgumentException($"Unknown key: {keyName}");
        }

        var neighbors = CircleOfFifthsLibrary.Neighbors.TryGetValue(keyName.Trim(), out var keys)
            ? keys
            : [];

        return new RelatedKeyResult
        {
            RequestedKey = keyName,
            RelativeKey = relative,
            NeighborKeys = neighbors
        };
    }
}
