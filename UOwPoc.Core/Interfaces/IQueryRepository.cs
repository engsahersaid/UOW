using System.Linq.Expressions;
using UOwPoc.Core.Entities.Base;
using UOwPoc.Core.Models;

namespace UOwPoc.Core.Interfaces
{
    public interface IQueryRepository<T> where T : BaseAuditableEntity
    {
        T? GetById(Guid id);

        T? Get(Expression<Func<T, bool>> expression, string includeProperties = "");

        List<T> GetAll(string includeProperties = "");

        List<T> GetList(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "");

        PageResult<T> GetList(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "", int pageIndex = 1, int pageSize = 10);

        //IQueryable<T> FindQueryable(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);

        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<T?> GetAsync(Expression<Func<T, bool>> expression, string includeProperties = "", CancellationToken cancellationToken = default);

        Task<List<T>> GetAllAsync(string includeProperties = "", CancellationToken cancellationToken = default);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "", CancellationToken cancellationToken = default);

        Task<PageResult<T>> GetListAsync(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "", int pageIndex = 1, int pageSize = 10, CancellationToken cancellationToken = default);
    }
}