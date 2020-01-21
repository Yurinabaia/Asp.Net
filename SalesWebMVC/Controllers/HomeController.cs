using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesWebMVC.Models.ViewModels;

namespace SalesWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)//O mapeamento começar com Home
            //Tudo que eu colocar na pagina home vai busca a pargina
            //Tipo home/index vai entra na pagina inicia etc
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Aqui podemos definir uma mensagem 
            //Usando o ViewData["Mensagem"]
            ViewData["Mensagem"] = "Olá mundo"; //Definimos a mensagem
            //Agora defemos ir na nossa View  e mecher com Index intanciando a mensagem criada
            return View(); //Usando o comando CTRL e Space você pode usar alguma propriedade do return
            //Todo return tem propriedades definidas
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
