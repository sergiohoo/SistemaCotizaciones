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
    public class ContactosClientesFinalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactosClientesFinalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContactosClientesFinales
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ContactosClientesFinales.Include(c => c.ClienteFinal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ContactosClientesFinales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContactosClientesFinales == null)
            {
                return NotFound();
            }

            var contactoClienteFinal = await _context.ContactosClientesFinales
                .Include(c => c.ClienteFinal)
                .FirstOrDefaultAsync(m => m.ContactoClienteFinalId == id);
            if (contactoClienteFinal == null)
            {
                return NotFound();
            }

            return View(contactoClienteFinal);
        }

        // GET: ContactosClientesFinales/Create
        public IActionResult Create()
        {
            ViewData["ClienteFinalId"] = new SelectList(_context.ClientesFinales, "ClienteFinalId", nameof(ClienteFinal.RazonSocial));
            return View();
        }

        // POST: ContactosClientesFinales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactoClienteFinalId,ClienteFinalId,Rut,Nombre,Apellido,Email,Telefono")] ContactoClienteFinal contactoClienteFinal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactoClienteFinal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteFinalId"] = new SelectList(_context.ClientesFinales, "ClienteFinalId", nameof(ClienteFinal.RazonSocial), contactoClienteFinal.ClienteFinalId);
            return View(contactoClienteFinal);
        }

        // GET: ContactosClientesFinales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContactosClientesFinales == null)
            {
                return NotFound();
            }

            var contactoClienteFinal = await _context.ContactosClientesFinales.FindAsync(id);
            if (contactoClienteFinal == null)
            {
                return NotFound();
            }
            ViewData["ClienteFinalId"] = new SelectList(_context.ClientesFinales, "ClienteFinalId", nameof(ClienteFinal.RazonSocial), contactoClienteFinal.ClienteFinalId);
            return View(contactoClienteFinal);
        }

        // POST: ContactosClientesFinales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactoClienteFinalId,ClienteFinalId,Rut,Nombre,Apellido,Email,Telefono")] ContactoClienteFinal contactoClienteFinal)
        {
            if (id != contactoClienteFinal.ContactoClienteFinalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactoClienteFinal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoClienteFinalExists(contactoClienteFinal.ContactoClienteFinalId))
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
            ViewData["ClienteFinalId"] = new SelectList(_context.ClientesFinales, "ClienteFinalId", nameof(ClienteFinal.RazonSocial), contactoClienteFinal.ClienteFinalId);
            return View(contactoClienteFinal);
        }

        // GET: ContactosClientesFinales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContactosClientesFinales == null)
            {
                return NotFound();
            }

            var contactoClienteFinal = await _context.ContactosClientesFinales
                .Include(c => c.ClienteFinal)
                .FirstOrDefaultAsync(m => m.ContactoClienteFinalId == id);
            if (contactoClienteFinal == null)
            {
                return NotFound();
            }

            return View(contactoClienteFinal);
        }

        // POST: ContactosClientesFinales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContactosClientesFinales == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ContactosClientesFinales'  is null.");
            }
            var contactoClienteFinal = await _context.ContactosClientesFinales.FindAsync(id);
            if (contactoClienteFinal != null)
            {
                _context.ContactosClientesFinales.Remove(contactoClienteFinal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoClienteFinalExists(int id)
        {
          return (_context.ContactosClientesFinales?.Any(e => e.ContactoClienteFinalId == id)).GetValueOrDefault();
        }
    }
}
