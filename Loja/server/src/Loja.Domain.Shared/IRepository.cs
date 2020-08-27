using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.Shared
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
