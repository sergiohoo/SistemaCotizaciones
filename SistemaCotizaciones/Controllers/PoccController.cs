using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaCotizaciones.Model;
using SistemaCotizaciones.Models;

namespace SistemaCotizaciones.Controllers
{
    public class PoccController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoccController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(int? id)
        {
            if (id != null)
            {
                var cotizacion = _context.Cotizaciones.Where(c => c.CotizacionId == id)
                                    .Include(c => c.MaterialesCotizacion).ThenInclude(m => m.Material)
                                    .Include(c => c.Canal)
                                    .Include(c => c.ContactoCanal)
                                    .Include(c => c.ClienteFinal)
                                    .Include(c => c.ContactoClienteFinal)
                                    .Include(c => c.Fabricante)
                                    .FirstOrDefault();

                var pocc = _context.Pocc.Where(p => p.CotizacionId == id).FirstOrDefault();
                if (pocc == null)
                {
                    pocc = new Pocc();
                    pocc.CotizacionId = cotizacion.CotizacionId;
                }

                var model = new PoccCreateViewModel
                {
                    cotizacion = cotizacion,
                    pocc = pocc
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Cotizaciones");
            }
        }

        [HttpPost]
        public IActionResult Create(Pocc pocc, Cotizacion cotizacion)
        {
            if (pocc != null && cotizacion != null)
            {
                if (pocc.PoccId == 0)
                {
                    _context.Pocc.Add(pocc);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Update(pocc);
                    _context.SaveChanges();
                }

                foreach (var _material in cotizacion.MaterialesCotizacion)
                {
                    var material = _context.MaterialesCotizacion.Where(m => m.MaterialCotizacionId == _material.MaterialCotizacionId).FirstOrDefault();
                    if (material != null)
                    {
                        material.CodigoImpulse = _material.CodigoImpulse;
                        _context.Update(material);
                        _context.SaveChanges();
                    }
                }

                return RedirectToAction("Excel","Pocc",new {id = cotizacion.CotizacionId});
            }
            else
            {
                return RedirectToAction("Index", "Cotizaciones");
            }

        }

        public IActionResult Excel(int? id)
        {
            if (id != null)
            {
                var cotizacion = _context.Cotizaciones.Where(c => c.CotizacionId == id)
                                    .Include(c => c.MaterialesCotizacion).ThenInclude(m => m.Material)
                                    .Include(c => c.Canal)
                                    .Include(c => c.ContactoCanal)
                                    .Include(c => c.ClienteFinal)
                                    .Include(c => c.ContactoClienteFinal)
                                    .Include(c => c.Fabricante)
                                    .FirstOrDefault();

                var pocc = _context.Pocc.Where(p => p.CotizacionId == id).FirstOrDefault();
                if (pocc == null)
                {
                    pocc = new Pocc();
                    pocc.CotizacionId = cotizacion.CotizacionId;
                }

                var model = new PoccCreateViewModel
                {
                    cotizacion = cotizacion,
                    pocc = pocc
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Cotizaciones");
            }
        }
    }
}
