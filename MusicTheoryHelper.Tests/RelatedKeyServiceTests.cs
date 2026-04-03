using MusicTheoryHelper.Core.Services;

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
}
