namespace MusicTheoryHelper.Core.Helpers;

public static class NoteNormalizationHelper
{
    private static readonly HashSet<string> ValidNotes =
    ["C","C#","Db","D","D#","Eb","E","F","F#","Gb","G","G#","Ab","A","A#","Bb","B"];

    public static string Normalize(string raw)
    {
        var trimmed = raw.Trim();
        if (trimmed.Length == 0)
        {
            return string.Empty;
        }

        var note = char.ToUpperInvariant(trimmed[0]) + trimmed[1..].Replace('♯', '#').Replace('♭', 'b').ToLowerInvariant();
        if (note.Length == 2)
        {
            note = $"{note[0]}{(note[1] == 'b' ? 'b' : '#')}";
        }

        return note;
    }

    public static bool IsValid(string note) => ValidNotes.Contains(note);
}
