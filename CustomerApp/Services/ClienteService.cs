using CustomerApp.Data;
using CustomerApp.Entities;
using Microsoft.UI.Xaml.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Services
{
    internal class ClienteService : DatabaseContext, IAbstractService<Cliente>
    {
        public ClienteService() { }

        public async Task<List<Cliente>> GetAllAsync()
        {
            var Clientes = await GetAllAsync<Cliente>();
            return Clientes.ToList();
        }

        public async Task<Cliente> GetByIdAsync(object primaryKey)
        {
            return await GetByIdAsync<Cliente>(primaryKey);
        }

        public async Task<List<Cliente>> GetFilteredAsync(Expression<Func<Cliente, bool>> predicate)
        {
            var Clientes = await GetFilteredAsync<Cliente>(predicate);
            return Clientes.ToList();
        }

        public async Task<bool> InsertAsync(Cliente item)
        {
            return await InsertAsync<Cliente>(item);
        }

        public async Task<bool> UpdateAsync(Cliente item)
        {
            return await UpdateAsync<Cliente>(item);
        }

        public async Task<bool> SaveAsync(Cliente item)
        {   if (item.Id != 0)
            {
                var cliente = await GetByIdAsync<Cliente>(item.Id);
                return await UpdateAsync(item);
            }
            else
                return await InsertAsync(item);
        }

        public async Task<bool> DeleteAsync(Cliente item)
        {
            return await DeleteAsync<Cliente>(item);
        }

        public async Task<bool> DeleteByIdAsync(object primaryKey)
        {
            return await DeleteByIdAsync<Cliente>(primaryKey);
        }
    }
}
