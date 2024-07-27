using System.Collections.Generic;
using System;
using System.Linq;

namespace WebVendasMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(int id, int name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            //Foi pego cada vendededor da lista chamando o totalSales do vendedor naquele período
            // Inicial e final, e ai foi feito a soma do resultado pra todos os vendedores desse departamento
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
