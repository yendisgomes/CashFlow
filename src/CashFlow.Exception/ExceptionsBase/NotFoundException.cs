using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Exception.ExceptionsBase
{
    public class NotFoundException : CashFlowException
    {
        public NotFoundException(string message) : base(message)
        {
            
        }
        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErros()
        {
            return [Message];
        }
    }
}
