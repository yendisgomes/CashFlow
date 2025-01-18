using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf
{
    public class GenerateExpensesReportPdfUseCase : IGenerateExpensesReportPdfUseCase
    {
        private const string CURRENCY_SYMBOL = "R$";
        public async Task<byte[]> Execute(DateOnly month)
        {
            //var expenses = await _repository.FilterByMonth(month);
            //if (expenses.Count == 0)
            //    return [];

            return [];
        }
    }
}
