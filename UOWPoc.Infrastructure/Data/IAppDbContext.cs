using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace UOWPoc.Infrastructure.Data
{
    public interface IAppDbContext : IDisposable
    {
        EntityEntry Entry(object entity);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}