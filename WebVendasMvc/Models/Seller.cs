using System;
using System.Collections.Generic;
using System.Linq;


namespace WebVendasMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public double BaseSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;

        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        //Total de vendas em determinado período de tempo
        public double TotalSales(DateTime initial, DateTime final)
        {
            //Foi utilizado o linq
            //chamando a coleção Sales que seria a lista de venda de venda associadas com determinado vendedor
            //where usado pra filtrar a lista de venda pra obter uma nova lista contendo apenas a lista no tempo especificado
            //Feito a filtragem, entra a soma do sr que leva em sr amount pois quero a soma das vendas
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }

    }
}
