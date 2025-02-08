using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Security.Crryptography
{
    public interface IPasswordEncripter 
    {
        string Encrypt(string password);
        
    }
}
