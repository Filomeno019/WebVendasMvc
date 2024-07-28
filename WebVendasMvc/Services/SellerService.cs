using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMvc.Models;
using Microsoft.EntityFrameworkCore;
using WebVendasMvc.Services.Exceptions;

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

        public void Insert(Seller obj) 
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {

            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id) 
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            //Interceptacão de excessão a nivel de BD
            catch(DbUpdateConcurrencyException e)
            {
                //e lançando a nível de serviço
                throw new DbConcurrencyException(e.Message);
            }

            
        }
    }
}
