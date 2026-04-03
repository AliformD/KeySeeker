using MusicTheoryHelper.Core.Services;

namespace MusicTheoryHelper.Tests;

public sealed class KeyServiceTests
{
    [Fact]
    public void GetNotesInKey_ReturnsExpectedNotes()
    {
        var service = new KeyService();

        var notes = service.GetNotesInKey("G major");

        Assert.Equal(["G", "A", "B", "C", "D", "E", "F#"], notes);
    }
}
