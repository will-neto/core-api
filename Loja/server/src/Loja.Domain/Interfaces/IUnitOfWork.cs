using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
