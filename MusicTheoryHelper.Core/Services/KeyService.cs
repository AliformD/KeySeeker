using MusicTheoryHelper.Core.Data;
using MusicTheoryHelper.Core.Interfaces;
using MusicTheoryHelper.Core.Models;

namespace MusicTheoryHelper.Core.Services;

public sealed class KeyService : IKeyService
{
    public IReadOnlyList<KeySignature> GetAllKeys() => KeyLibrary.All;

    public IReadOnlyList<string> GetNotesInKey(string keyName)
    {
        if (!TryGetKey(keyName, out var key))
        {
            throw new ArgumentException($"Unknown key: {keyName}");
        }

        return key.Notes;
    }

    public bool TryGetKey(string keyName, out KeySignature key)
    {
        key = KeyLibrary.All.FirstOrDefault(k => string.Equals(k.Name, keyName.Trim(), StringComparison.OrdinalIgnoreCase))!;
        return key is not null;
    }
}
