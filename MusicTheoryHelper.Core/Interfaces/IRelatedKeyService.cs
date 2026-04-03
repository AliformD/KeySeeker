using MusicTheoryHelper.Core.Models;

namespace MusicTheoryHelper.Core.Interfaces;

public interface IRelatedKeyService
{
    RelatedKeyResult GetRelatedKeys(string keyName);
}
