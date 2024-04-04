using LPSTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace LPSTest.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        private IConfiguration _configuration;

        public LoginController(ILogger<LoginController> logger, IConfiguration iconfig)
        {
            _configuration = iconfig;
            _logger = logger;
        }

        public IActionResult Index()
        {
            string urlAPI = _configuration.GetValue<string>("UrlAPI");
            ViewBag.UrlAPI = urlAPI;
            
            var _Session = HttpContext.Session.GetObject<SessionModel>("_Session") ?? new SessionModel();
            // Periksa apakah objek _Session tidak null dan accessToken tidak kosong
            if (!string.IsNullOrEmpty(_Session.accessToken))
            {
                return RedirectToAction("Index", "Dashboard", new { area = "" });
            }
            else
            {
                return View();
                // Redirect ke halaman login jika tidak ada token accessToken dalam session
            }
        }
        
        [HttpPost]
        public IActionResult AddSession([FromBody] SessionModel dataPost)
        {
            string urlAPI = _configuration.GetValue<string>("UrlAPI");
            ViewBag.UrlAPI = urlAPI;
            //simpan data post ke Session
            HttpContext.Session.SetObject("_Session", dataPost);
            var responseData = new
            {
                status = "success",
                data = dataPost
            };
            return Json(responseData);
        }

        [HttpGet]
        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
