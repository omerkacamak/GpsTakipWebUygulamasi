using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace proje.webui.Controllers
{
    public class CikisController:Controller
    {
        private readonly ILogger<CikisController> _logger;

        public CikisController(ILogger<CikisController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.Clear();
           // System.Console.WriteLine(HttpContext.Session.GetString("asd"));
            return RedirectToAction("Index","Giris");
        
        }
        public IActionResult Kontrol()
        {
            return View();
        }

        
    }
}