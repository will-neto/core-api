using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.Shared
{
    public interface IRepository<T> where T : IAggregateRoot
    {

    }
}
