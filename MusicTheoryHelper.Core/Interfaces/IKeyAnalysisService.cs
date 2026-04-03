using MusicTheoryHelper.Core.Models;

namespace MusicTheoryHelper.Core.Interfaces;

public interface IKeyAnalysisService
{
    AnalysisResult AnalyzeNotes(IReadOnlyCollection<string> inputNotes);
}
