using CashFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Extensions
{
    public static class PaymentTypeExtensions
    {
        public static string PaymentTypeToString(this PaymentType paymentType)
        {
            return paymentType switch
            {
                PaymentType.Cash => "Dinheiro",
                PaymentType.CreditCard => "Cartão de Crédito",
                PaymentType.DebitCard => "Cartão de débito",
                PaymentType.EletronicTransfer => "Transferência Bancária",
                _ => string.Empty
            };
        }
    }
}
