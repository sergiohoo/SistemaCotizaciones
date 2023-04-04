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
    public class ClientesFinalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesFinalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClientesFinales
        public async Task<IActionResult> Index()
        {
              return _context.ClientesFinales != null ? 
                          View(await _context.ClientesFinales.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ClientesFinales'  is null.");
        }

        // GET: ClientesFinales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClientesFinales == null)
            {
                return NotFound();
            }

            var clienteFinal = await _context.ClientesFinales
                .FirstOrDefaultAsync(m => m.ClienteFinalId == id);
            if (clienteFinal == null)
            {
                return NotFound();
            }

            return View(clienteFinal);
        }

        // GET: ClientesFinales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientesFinales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteFinalId,Rut,RazonSocial,Telefono,Direccion,Email")] ClienteFinal clienteFinal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteFinal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteFinal);
        }

        // GET: ClientesFinales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClientesFinales == null)
            {
                return NotFound();
            }

            var clienteFinal = await _context.ClientesFinales.FindAsync(id);
            if (clienteFinal == null)
            {
                return NotFound();
            }
            return View(clienteFinal);
        }

        // POST: ClientesFinales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteFinalId,Rut,RazonSocial,Telefono,Direccion,Email")] ClienteFinal clienteFinal)
        {
            if (id != clienteFinal.ClienteFinalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteFinal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteFinalExists(clienteFinal.ClienteFinalId))
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
            return View(clienteFinal);
        }

        // GET: ClientesFinales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientesFinales == null)
            {
                return NotFound();
            }

            var clienteFinal = await _context.ClientesFinales
                .FirstOrDefaultAsync(m => m.ClienteFinalId == id);
            if (clienteFinal == null)
            {
                return NotFound();
            }

            return View(clienteFinal);
        }

        // POST: ClientesFinales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientesFinales == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ClientesFinales'  is null.");
            }
            var clienteFinal = await _context.ClientesFinales.FindAsync(id);
            if (clienteFinal != null)
            {
                _context.ClientesFinales.Remove(clienteFinal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteFinalExists(int id)
        {
          return (_context.ClientesFinales?.Any(e => e.ClienteFinalId == id)).GetValueOrDefault();
        }
    }
}
