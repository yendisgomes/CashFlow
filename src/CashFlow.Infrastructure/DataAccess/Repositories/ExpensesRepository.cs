using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpensesRepository
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
    }
}
