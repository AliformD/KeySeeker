using MusicTheoryHelper.Core.Models;

namespace MusicTheoryHelper.Core.Interfaces;

public interface IKeyService
{
    IReadOnlyList<string> GetNotesInKey(string keyName);
    bool TryGetKey(string keyName, out KeySignature key);
    IReadOnlyList<KeySignature> GetAllKeys();
}
