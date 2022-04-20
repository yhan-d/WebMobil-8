using Microsoft.AspNetCore.Mvc;

namespace AdminTemplate.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
