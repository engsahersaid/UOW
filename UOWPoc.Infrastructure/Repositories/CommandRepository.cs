using Microsoft.EntityFrameworkCore;
using UOwPoc.Core.Entities.Base;
using UOwPoc.Core.Interfaces;
using UOWPoc.Infrastructure.Data;

namespace UOWPoc.Infrastructure.Repositories
{
    public class CommandRepository<T> : ICommandRepository<T> where T : BaseAuditableEntity
    {
        private readonly IAppDbContext _dbContext;

        public CommandRepository(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }
        public void Add(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }
        
        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            entity.lastUpdatedAt = DateTime.Now;
            _dbContext.Set<T>().Update(entity);
        }
        public void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                entity.lastUpdatedAt = DateTime.Now;
            }
            _dbContext.Set<T>().UpdateRange(entities);
        }
        
        public void Delete(Guid id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            if (entity == null)
                throw new Exception("Entity Not found");
            this.Delete(entity);
        }
        public void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            entity.Delete();
            _dbContext.Set<T>().Update(entity);
        }
        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                this.Delete(entity);
        }
        
        public void PermenemtDelete(Guid id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            if (entity == null)
                throw new Exception("Entity Not found");
            this.PermenemtDelete(entity);
        }
        public void PermenemtDelete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
        public void PermenemtDelete(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }
        
        public void AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().AddAsync(entity, cancellationToken);
        }
        public void AddAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().AddRangeAsync(entities, cancellationToken);
        }

        /*public void UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Set<T>().Update(entity);
        }
        public void UpdateAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
                _dbContext.Entry(entity).State = EntityState.Modified;

            _dbContext.Set<T>().UpdateRange(entities);
        }

        public void DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = _dbContext.Set<T>().Find(id);
            if (entity == null)
                throw new Exception("Entity Not found");
            this.Delete(entity);
        }
        public void DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            entity.IsDeleted = true;
            _dbContext.Set<T>().Update(entity);
        }
        public void DeleteAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
                this.Delete(entity);
        }

        public void PermenemtDeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = _dbContext.Set<T>().Find(id);
            if (entity == null)
                throw new Exception("Entity Not found");
            this.PermenemtDelete(entity);
        }
        public void PermenemtDeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Remove(entity);
        }
        public void PermenemtDeleteAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }*/
    }
}