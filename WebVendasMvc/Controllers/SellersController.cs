using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendasMvc.Controllers
{

    //Controlador de Sellers, é quem recebe a chamada do caminho "/Sellers" Ele encaminha a requisição para a view
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
