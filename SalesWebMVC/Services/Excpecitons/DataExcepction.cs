using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services.Excpecitons
{
    public class DataExcepction : ApplicationException
    {
        public DataExcepction (string mensagem) : base(mensagem) 
        {
        }
    }
}
