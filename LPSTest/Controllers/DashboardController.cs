using LPSTest.Models;
using Microsoft.AspNetCore.Mvc;
namespace LPSTest.Controllers
{
    public class DashboardController : Controller
    {

        private readonly ILogger<DashboardController> _logger;

        private IConfiguration _configuration;

        public const string accessToken = "accessToken";

        public DashboardController(ILogger<DashboardController> logger, IConfiguration iconfig)
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
                return View();
            }
            else
            {
                // Redirect ke halaman login jika tidak ada token accessToken dalam session
                return RedirectToAction("Index", "Login", new { area = "" });
            }
        }
    }
}
