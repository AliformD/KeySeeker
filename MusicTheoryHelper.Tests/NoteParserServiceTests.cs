using MusicTheoryHelper.Core.Services;

namespace MusicTheoryHelper.Tests;

public sealed class NoteParserServiceTests
{
    [Fact]
    public void ParseNotes_NormalizesAndDeduplicates()
    {
        var service = new NoteParserService();

        var result = service.ParseNotes("c, E, g, C");

        Assert.Equal(["C", "E", "G"], result);
    }

    [Fact]
    public void ParseNotes_ThrowsOnInvalidNotes()
    {
        var service = new NoteParserService();

        Assert.Throws<ArgumentException>(() => service.ParseNotes("C H G"));
    }
}
