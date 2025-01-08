using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpenseReadOnlyRespository, IExpenseWriteOnlyRepository
    {
        private readonly CashflowDbContext _context;

        public ExpensesRepository(CashflowDbContext context)
        {
            _context = context;
        }
        public async Task Add(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
        }

        public async Task<List<Expense>> GetAll()
        {
            return await _context.Expenses.AsNoTracking().ToListAsync();
        }

        public async Task<Expense?> GetById(long id)
        {
            return await _context.Expenses.AsNoTracking().FirstOrDefaultAsync(expense => expense.Id == id);
        }
    }
}
