using Microsoft.AspNetCore.Mvc;

namespace harmic.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password, bool RememberMe)
        {
           
            if (Username == "admin" && Password == "12345")
            {
               
                HttpContext.Session.SetString("AdminUsername", Username);
                return RedirectToAction("Index");
            }

            
            ViewBag.ErrorMessage = "Nhập lại tài khoản hoặc mật khẩu.";
            return View();
        }
    }
}
