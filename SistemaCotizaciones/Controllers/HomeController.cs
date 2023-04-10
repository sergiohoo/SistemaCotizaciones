using Microsoft.AspNetCore.Mvc;
using SistemaCotizaciones.Model;
using SistemaCotizaciones.Models;
using System.Diagnostics;

namespace SistemaCotizaciones.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(string user, string pass)
        {
            if (user != null && pass != null)
            {
                var _user = _context.Usuarios.Where(u => u.NombreUsuario == user).FirstOrDefault();
                if (_user != null && _user.Contraseña == pass)
                {
                    return RedirectToAction("Index", "Cotizaciones");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}