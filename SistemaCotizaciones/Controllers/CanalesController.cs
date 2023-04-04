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
    public class CanalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CanalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Canales
        public async Task<IActionResult> Index()
        {
              return _context.Canales != null ? 
                          View(await _context.Canales.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Canales'  is null.");
        }

        // GET: Canales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Canales == null)
            {
                return NotFound();
            }

            var canal = await _context.Canales
                .FirstOrDefaultAsync(m => m.CanalId == id);
            if (canal == null)
            {
                return NotFound();
            }

            return View(canal);
        }

        // GET: Canales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Canales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CanalId,Rut,RazonSocial,Telefono,Direccion,Email,NumeroClienteIngram")] Canal canal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(canal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(canal);
        }

        // GET: Canales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Canales == null)
            {
                return NotFound();
            }

            var canal = await _context.Canales.FindAsync(id);
            if (canal == null)
            {
                return NotFound();
            }
            return View(canal);
        }

        // POST: Canales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CanalId,Rut,RazonSocial,Telefono,Direccion,Email,NumeroClienteIngram")] Canal canal)
        {
            if (id != canal.CanalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(canal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CanalExists(canal.CanalId))
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
            return View(canal);
        }

        // GET: Canales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Canales == null)
            {
                return NotFound();
            }

            var canal = await _context.Canales
                .FirstOrDefaultAsync(m => m.CanalId == id);
            if (canal == null)
            {
                return NotFound();
            }

            return View(canal);
        }

        // POST: Canales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Canales == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Canales'  is null.");
            }
            var canal = await _context.Canales.FindAsync(id);
            if (canal != null)
            {
                _context.Canales.Remove(canal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CanalExists(int id)
        {
          return (_context.Canales?.Any(e => e.CanalId == id)).GetValueOrDefault();
        }
    }
}
