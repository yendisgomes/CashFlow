﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Exception.ExceptionsBase
{
    public abstract class CashFlowException : SystemException
    {
        protected CashFlowException(string message) : base(message)
        {

        }

        public abstract int StatusCode { get; }
        public abstract List<string> GetErros();
    }
}
