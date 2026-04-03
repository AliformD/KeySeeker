namespace MusicTheoryHelper.Core.Models;

public sealed class AnalysisResult
{
    public IReadOnlyList<string> PossibleChords { get; init; } = [];
    public IReadOnlyList<string> PossibleKeys { get; init; } = [];
}
