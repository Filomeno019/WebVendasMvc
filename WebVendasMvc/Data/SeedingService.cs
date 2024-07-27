using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMvc.Models;
using WebVendasMvc.Models.Enums;

namespace WebVendasMvc.Data
{
    public class SeedingService
    {
        private WebVendasMvcContext _context;

        //Injeção de dependência, ou seja quando um seedingService for criado automaticamente ele recebe uma instãncia do 
        //Context tambem
        public SeedingService(WebVendasMvcContext context)
        {
            _context = context;
        }

        //Responsável por popular a base de dados
        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; //DB já foi populado
            }

            Department d1 = new Department(1, 2);
            Department d2 = new Department(1, 21);
            Department d3 = new Department(1, 221);
            Department d4 = new Department(1, 2221);

            Seller s1 = new Seller(1, "Filomeno", "Filo@gmail.com", new DateTime(2001, 8, 14), 1000.0, d1);
            Seller s2 = new Seller(3, "Falamenos", "Filozasso@gmail.com", new DateTime(2004, 9, 15), 1500.0, d4);
            Seller s3 = new Seller(4, "Falamansa", "Filozin@gmail.com", new DateTime(2006, 10, 16), 2000.0, d2);
            Seller s4 = new Seller(5, "Salamandra", "Filozao@gmail.com", new DateTime(2008, 11, 17), 2500.0, d3);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.billed, s1);

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4);

            _context.SalesRecord.AddRange(r1);

            _context.SaveChanges();
        }
    }

}

