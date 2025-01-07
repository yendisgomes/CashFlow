﻿using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
