using UOwPoc.Core.Entities.Base;
using UOwPoc.Core.Interfaces;
using UOWPoc.Infrastructure.Data;

namespace UOWPoc.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAppDbContext _databaseContext;
        private bool _disposed;

        public UnitOfWork(IAppDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        //public IRepository<T> Repository<T>() where T : BaseEntity, new()
        //{
        //    return new Repository<T>(_databaseContext);
        //}
        public ILookupRepository<T> LookupRepository<T>() where T : BaseLookupEntity, new()
        {
            return new LookupRepository<T>(_databaseContext);
        }

        public IQueryRepository<T> QueryRepository<T>() where T : BaseAuditableEntity, new()
        {
            return new QueryRepository<T>(_databaseContext);
        }

        public ICommandRepository<T> CommandRepository<T>() where T : BaseAuditableEntity, new()
        {
            return new CommandRepository<T>(_databaseContext);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _databaseContext.SaveChangesAsync(cancellationToken);
        }

        public int SaveChanges()
        {
            return _databaseContext.SaveChanges();
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _databaseContext.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}