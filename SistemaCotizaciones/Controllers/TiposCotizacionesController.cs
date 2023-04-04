using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaCotizaciones.Model;

namespace SistemaCotizaciones.Controllers
{
    public class TiposCotizacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TiposCotizacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TiposCotizaciones
        public async Task<IActionResult> Index()
        {
              return _context.TiposCotizacion != null ? 
                          View(await _context.TiposCotizacion.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TiposCotizacion'  is null.");
        }

        // GET: TiposCotizaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiposCotizacion == null)
            {
                return NotFound();
            }

            var tipoCotizacion = await _context.TiposCotizacion
                .FirstOrDefaultAsync(m => m.TipoCotizacionId == id);
            if (tipoCotizacion == null)
            {
                return NotFound();
            }

            return View(tipoCotizacion);
        }

        // GET: TiposCotizaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposCotizaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoCotizacionId,Nombre")] TipoCotizacion tipoCotizacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoCotizacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoCotizacion);
        }

        // GET: TiposCotizaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiposCotizacion == null)
            {
                return NotFound();
            }

            var tipoCotizacion = await _context.TiposCotizacion.FindAsync(id);
            if (tipoCotizacion == null)
            {
                return NotFound();
            }
            return View(tipoCotizacion);
        }

        // POST: TiposCotizaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoCotizacionId,Nombre")] TipoCotizacion tipoCotizacion)
        {
            if (id != tipoCotizacion.TipoCotizacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoCotizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoCotizacionExists(tipoCotizacion.TipoCotizacionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoCotizacion);
        }

        // GET: TiposCotizaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiposCotizacion == null)
            {
                return NotFound();
            }

            var tipoCotizacion = await _context.TiposCotizacion
                .FirstOrDefaultAsync(m => m.TipoCotizacionId == id);
            if (tipoCotizacion == null)
            {
                return NotFound();
            }

            return View(tipoCotizacion);
        }

        // POST: TiposCotizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiposCotizacion == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TiposCotizacion'  is null.");
            }
            var tipoCotizacion = await _context.TiposCotizacion.FindAsync(id);
            if (tipoCotizacion != null)
            {
                _context.TiposCotizacion.Remove(tipoCotizacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoCotizacionExists(int id)
        {
          return (_context.TiposCotizacion?.Any(e => e.TipoCotizacionId == id)).GetValueOrDefault();
        }
    }
}
