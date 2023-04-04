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
    public class TiposComprasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TiposComprasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TiposCompras
        public async Task<IActionResult> Index()
        {
              return _context.TiposCompra != null ? 
                          View(await _context.TiposCompra.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TiposCompra'  is null.");
        }

        // GET: TiposCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiposCompra == null)
            {
                return NotFound();
            }

            var tipoCompra = await _context.TiposCompra
                .FirstOrDefaultAsync(m => m.TipoCompraId == id);
            if (tipoCompra == null)
            {
                return NotFound();
            }

            return View(tipoCompra);
        }

        // GET: TiposCompras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoCompraId,Nombre")] TipoCompra tipoCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoCompra);
        }

        // GET: TiposCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiposCompra == null)
            {
                return NotFound();
            }

            var tipoCompra = await _context.TiposCompra.FindAsync(id);
            if (tipoCompra == null)
            {
                return NotFound();
            }
            return View(tipoCompra);
        }

        // POST: TiposCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoCompraId,Nombre")] TipoCompra tipoCompra)
        {
            if (id != tipoCompra.TipoCompraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoCompraExists(tipoCompra.TipoCompraId))
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
            return View(tipoCompra);
        }

        // GET: TiposCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiposCompra == null)
            {
                return NotFound();
            }

            var tipoCompra = await _context.TiposCompra
                .FirstOrDefaultAsync(m => m.TipoCompraId == id);
            if (tipoCompra == null)
            {
                return NotFound();
            }

            return View(tipoCompra);
        }

        // POST: TiposCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiposCompra == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TiposCompra'  is null.");
            }
            var tipoCompra = await _context.TiposCompra.FindAsync(id);
            if (tipoCompra != null)
            {
                _context.TiposCompra.Remove(tipoCompra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoCompraExists(int id)
        {
          return (_context.TiposCompra?.Any(e => e.TipoCompraId == id)).GetValueOrDefault();
        }
    }
}
