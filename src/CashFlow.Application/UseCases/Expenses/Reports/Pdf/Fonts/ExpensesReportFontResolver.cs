using PdfSharp.Fonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts
{
    public class ExpensesReportFontResolver : IFontResolver
    {
        public byte[]? GetFont(string faceName)
        {
            throw new NotImplementedException();
        }

        public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
        {
            throw new NotImplementedException();
        }
    }
}
