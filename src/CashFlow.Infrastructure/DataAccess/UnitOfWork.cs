using CashFlow.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Infrastructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CashflowDbContext _context;

        public UnitOfWork(CashflowDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
