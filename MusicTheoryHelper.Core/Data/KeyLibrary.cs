using MusicTheoryHelper.Core.Models;

namespace MusicTheoryHelper.Core.Data;

public static class KeyLibrary
{
    public static IReadOnlyList<KeySignature> All { get; } =
    [
        new() { Name = "C major", Mode = "Major", Notes = ["C", "D", "E", "F", "G", "A", "B"] },
        new() { Name = "G major", Mode = "Major", Notes = ["G", "A", "B", "C", "D", "E", "F#"] },
        new() { Name = "D major", Mode = "Major", Notes = ["D", "E", "F#", "G", "A", "B", "C#"] },
        new() { Name = "A major", Mode = "Major", Notes = ["A", "B", "C#", "D", "E", "F#", "G#"] },
        new() { Name = "F major", Mode = "Major", Notes = ["F", "G", "A", "Bb", "C", "D", "E"] },
        new() { Name = "Bb major", Mode = "Major", Notes = ["Bb", "C", "D", "Eb", "F", "G", "A"] },
        new() { Name = "A minor", Mode = "Minor", Notes = ["A", "B", "C", "D", "E", "F", "G"] },
        new() { Name = "E minor", Mode = "Minor", Notes = ["E", "F#", "G", "A", "B", "C", "D"] },
        new() { Name = "D minor", Mode = "Minor", Notes = ["D", "E", "F", "G", "A", "Bb", "C"] },
        new() { Name = "G minor", Mode = "Minor", Notes = ["G", "A", "Bb", "C", "D", "Eb", "F"] },
        new() { Name = "B minor", Mode = "Minor", Notes = ["B", "C#", "D", "E", "F#", "G", "A"] },
        new() { Name = "F# minor", Mode = "Minor", Notes = ["F#", "G#", "A", "B", "C#", "D", "E"] }
    ];
}
