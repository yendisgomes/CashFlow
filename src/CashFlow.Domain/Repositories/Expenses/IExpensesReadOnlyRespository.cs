using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpensesReadOnlyRespository
    {
        Task<List<Expense>> GetAll();
        Task<Expense?> GetById(long id);
        Task<List<Expense>> FilterByMonth(DateOnly date);
    }
}
