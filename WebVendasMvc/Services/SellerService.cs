using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMvc.Models;

namespace WebVendasMvc.Services
{
    public class SellerService
    {
        private readonly WebVendasMvcContext _context;

        public SellerService(WebVendasMvcContext context)
        {
            _context = context;
        }

        //implementacao para retorno da lista de vendedores
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
