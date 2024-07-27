using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMvc.Services;

namespace WebVendasMvc.Controllers
{

    //Controlador de Sellers, é quem recebe a chamada do caminho "/Sellers" Ele encaminha a requisição para a view
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            //Irá retornar uma lista de seller, e ela é passada como argumento no metodo view
            //Controlador foi chamado, acessou o model pegou o dado na lista e encaminha para a view
            var list = _sellerService.FindAll();

            return View(list);
        }
    }
}
