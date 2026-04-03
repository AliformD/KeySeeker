namespace MusicTheoryHelper.Core.Interfaces;

public interface INoteParserService
{
    IReadOnlyList<string> ParseNotes(string input);
}
