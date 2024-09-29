using UOwPoc.Core.Entities.Base;

namespace UOwPoc.Core.Interfaces
{
    public interface ILookupRepository<T> where T : BaseLookupEntity
    {
        List<T> GetAll();

        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}