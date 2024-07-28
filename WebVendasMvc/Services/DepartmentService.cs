using System.Collections.Generic;
using System.Linq;
using WebVendasMvc.Models;

namespace WebVendasMvc.Services
{
    public class DepartmentService
    {
        private readonly WebVendasMvcContext _context;

        public DepartmentService(WebVendasMvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll() 
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
