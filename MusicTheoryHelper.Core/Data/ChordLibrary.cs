using MusicTheoryHelper.Core.Models;

namespace MusicTheoryHelper.Core.Data;

public static class ChordLibrary
{
    public static IReadOnlyList<Chord> All { get; } =
    [
        new() { Name = "C major", ChordType = "Major", Notes = ["C", "E", "G"] },
        new() { Name = "A minor", ChordType = "Minor", Notes = ["A", "C", "E"] },
        new() { Name = "G major", ChordType = "Major", Notes = ["G", "B", "D"] },
        new() { Name = "D minor", ChordType = "Minor", Notes = ["D", "F", "A"] },
        new() { Name = "B diminished", ChordType = "Diminished", Notes = ["B", "D", "F"] },
        new() { Name = "C augmented", ChordType = "Augmented", Notes = ["C", "E", "G#"] }
    ];
}
