using MusicTheoryHelper.Core.Services;
using MusicTheoryHelper.Core.Data;

namespace MusicTheoryHelper.Tests;

public sealed class RelatedKeyServiceTests
{
    [Fact]
    public void GetRelatedKeys_ReturnsRelativeAndNeighbors()
    {
        var service = new RelatedKeyService();

        var result = service.GetRelatedKeys("A minor");

        Assert.Equal("C major", result.RelativeKey);
        Assert.Contains("E minor", result.NeighborKeys);
    }

    [Fact]
    public void GetRelatedKeys_AllReturnedNeighborsExistInKeyLibrary()
    {
        var service = new RelatedKeyService();
        var knownKeys = KeyLibrary.All
            .Select(key => key.Name)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        foreach (var keyName in CircleOfFifthsLibrary.Neighbors.Keys)
        {
            var result = service.GetRelatedKeys(keyName);

            Assert.All(result.NeighborKeys, neighbor => Assert.Contains(neighbor, knownKeys));
        }
    }
}
