using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess
{
    public class CashflowDbContext : DbContext
    {
        public CashflowDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Expense> Expenses { get; set; }
    }
}
