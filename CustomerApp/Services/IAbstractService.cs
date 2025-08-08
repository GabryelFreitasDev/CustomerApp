using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Services
{
    public interface IAbstractService<TTable>
    {
        Task<List<TTable>> GetAllAsync();
        Task<TTable> GetByIdAsync(object primaryKey);
        Task<List<TTable>> GetFilteredAsync(Expression<Func<TTable, bool>> predicate);
        Task<bool> InsertAsync(TTable item);
        Task<bool> UpdateAsync(TTable item);
        Task<bool> DeleteAsync(TTable item);
        Task<bool> DeleteByIdAsync(object primaryKey);
    }
}
