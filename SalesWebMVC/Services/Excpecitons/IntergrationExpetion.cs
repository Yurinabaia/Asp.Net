using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services.Excpecitons
{
    public class IntergrationExpetion : ApplicationException
    {
        public IntergrationExpetion(string mensagem ) : base(mensagem) { }
    }
}
