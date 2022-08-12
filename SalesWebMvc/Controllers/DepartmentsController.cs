using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> lis = new List<Department>();
            lis.Add(new Department { Id = 1, Name = "RH" });
            lis.Add(new Department { Id = 2, Name = "ALA" });

            return View(lis);
        }
    }
}
