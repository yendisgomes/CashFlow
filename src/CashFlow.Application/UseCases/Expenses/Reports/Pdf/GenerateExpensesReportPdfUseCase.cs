using CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repositories.Expenses;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Fonts;

namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf
{
    public class GenerateExpensesReportPdfUseCase : IGenerateExpensesReportPdfUseCase
    {
        private const string CURRENCY_SYMBOL = "R$";
        private readonly IExpensesReadOnlyRespository _repository;

        public GenerateExpensesReportPdfUseCase(IExpensesReadOnlyRespository repository)
        {
            _repository = repository;
            GlobalFontSettings.FontResolver = new ExpensesReportFontResolver();
        }

        public async Task<byte[]> Execute(DateOnly month)
        {
            var expenses = await _repository.FilterByMonth(month);
            if (expenses.Count == 0)
                return [];

            var document = CreateDocument(month);
            var page = CreatePage(document);


            var table = page.AddTable();
            table.AddColumn();
            table.AddColumn("300");

            var row = table.AddRow();
            row.Cells[0].AddImage("");

            row.Cells[1].AddParagraph("Hey, X");
            row.Cells[1].Format.Font = new Font { Name = FontHelper.RALEWAY_BLACK, Size = 16 };
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;


            var paragraph = page.AddParagraph();
            paragraph.Format.SpaceBefore = "40";
            paragraph.Format.SpaceAfter = "40";

            var title = string.Format(ResourceReportGenerationMessages.TOTAL_SPENT_IN, month.ToString("Y"));

            paragraph.AddFormattedText(title, new Font { Name = FontHelper.RALEWAY_REGULAR, Size = 15 });
            paragraph.AddLineBreak();

            var totalExpense = expenses.Sum(expense => expense.Amount);
            paragraph.AddFormattedText($"{CURRENCY_SYMBOL} {totalExpense}", new Font { Name = FontHelper.WORKSANS_BLACK, Size = 50 });

            return RenderDocument(document);
        }

        private Document CreateDocument(DateOnly month)
        {
            var document = new Document();

            document.Info.Title = $"{ResourceReportGenerationMessages.EXPENSE_FOR} {month:Y}";
            document.Info.Author = "CashFlow";

            var style = document.Styles["Normal"];
            style!.Font.Name = FontHelper.RALEWAY_REGULAR;

            return document;
        }

        private Section CreatePage(Document document)
        {
            var section = document.AddSection();
            section.PageSetup = document.DefaultPageSetup.Clone();
            section.PageSetup.PageFormat = PageFormat.A4;
            section.PageSetup.LeftMargin = 40;
            section.PageSetup.RightMargin = 40;
            section.PageSetup.TopMargin = 80;
            section.PageSetup.BottomMargin = 80;

            return section;
        }

        private byte[] RenderDocument(Document document)
        {
            var renderer = new PdfDocumentRenderer
            {
                Document = document
            };

            renderer.RenderDocument();

            using var file = new MemoryStream();
            renderer.PdfDocument.Save(file);

            return file.ToArray();
        }
    }
}