using Loja.Domain.Interfaces;
using Loja.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LojaDbContext _context;

        public UnitOfWork(LojaDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
