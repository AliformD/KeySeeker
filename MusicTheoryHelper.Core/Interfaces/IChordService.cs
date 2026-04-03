namespace MusicTheoryHelper.Core.Interfaces;

public interface IChordService
{
    IReadOnlyList<string> FindMatchingChords(IReadOnlyCollection<string> inputNotes);
}
