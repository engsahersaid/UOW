using Microsoft.EntityFrameworkCore;
using UOwPoc.Core.Entities.Base;
using UOwPoc.Core.Interfaces;
using UOWPoc.Infrastructure.Data;

namespace UOWPoc.Infrastructure.Repositories
{
    public class LookupRepository<T> : ILookupRepository<T> where T : BaseLookupEntity
    {
        private readonly IAppDbContext _dbContext;

        public LookupRepository(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _dbContext.Set<T>().ToListAsync(cancellationToken);
        }
    }
}