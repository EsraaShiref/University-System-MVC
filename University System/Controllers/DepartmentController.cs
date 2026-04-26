using Microsoft.AspNetCore.Mvc;

namespace University_System.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
