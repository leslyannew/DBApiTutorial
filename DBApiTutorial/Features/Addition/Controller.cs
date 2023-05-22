using Microsoft.AspNetCore.Mvc;

namespace DBApiTutorial.Features.Addition
{
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
