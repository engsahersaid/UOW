using UOwPoc.Core.Entities.Base;

namespace UOwPoc.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //IRepository<T> Repository<T>() where T : BaseEntity, new();
        ILookupRepository<T> LookupRepository<T>() where T : BaseLookupEntity, new();

        IQueryRepository<T> QueryRepository<T>() where T : BaseAuditableEntity, new();

        ICommandRepository<T> CommandRepository<T>() where T : BaseAuditableEntity, new();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        int SaveChanges();
    }
}