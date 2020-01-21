using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services.Excpecitons
{
    public class NotFoundExecption : ApplicationException
    {
        public NotFoundExecption(string mensagem) : base(mensagem) { }
    }
}
