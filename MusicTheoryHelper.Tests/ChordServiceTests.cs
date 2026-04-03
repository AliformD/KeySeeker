using MusicTheoryHelper.Core.Services;

namespace MusicTheoryHelper.Tests;

public sealed class ChordServiceTests
{
    [Fact]
    public void FindMatchingChords_MatchesMajorChord()
    {
        var service = new ChordService();

        var matches = service.FindMatchingChords(["C", "E", "G"]);

        Assert.Contains("C major", matches);
    }
}
