using UOwPoc.Core.Entities.Base;

namespace UOwPoc.Core.Interfaces
{
    public interface ICommandRepository<T> where T : BaseAuditableEntity
    {
        void Add(T entity);

        void Add(IEnumerable<T> entities);

        void Update(T entity);

        void Update(IEnumerable<T> entities);

        void Delete(Guid id);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);

        void PermenemtDelete(Guid id);

        void PermenemtDelete(T entity);

        void PermenemtDelete(IEnumerable<T> entities);

        /*IAddOrUpdateDescriptor AddOrUpdate(Entity entity);
        IEnumerable<IAddOrUpdateDescriptor> AddOrUpdate(IEnumerable<Entity> entities);*/

        void AddAsync(T entity, CancellationToken cancellationToken = default);

        void AddAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        /*void UpdateAsync(T entity, CancellationToken cancellationToken = default);
        void UpdateAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        void DeleteAsync(int id, CancellationToken cancellationToken = default);
        void DeleteAsync(T entity, CancellationToken cancellationToken = default);
        void DeleteAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        void PermenemtDeleteAsync(int id, CancellationToken cancellationToken = default);
        void PermenemtDeleteAsync(T entity, CancellationToken cancellationToken = default);
        void PermenemtDeleteAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);*/
    }
}