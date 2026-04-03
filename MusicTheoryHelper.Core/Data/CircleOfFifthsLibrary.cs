namespace MusicTheoryHelper.Core.Data;

public static class CircleOfFifthsLibrary
{
    public static IReadOnlyDictionary<string, string[]> Neighbors { get; } = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
    {
        ["C major"] = ["G major", "F major"],
        ["G major"] = ["D major", "C major"],
        ["D major"] = ["A major", "G major"],
        ["F major"] = ["C major", "Bb major"],
        ["A minor"] = ["E minor", "D minor"],
        ["E minor"] = ["B minor", "A minor"],
        ["D minor"] = ["A minor", "G minor"],
        ["B minor"] = ["F# minor", "E minor"]
    };
}
