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
    public class ContactosFabricantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactosFabricantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContactosFabricantes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ContactosFabricantes.Include(c => c.Fabricante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ContactosFabricantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContactosFabricantes == null)
            {
                return NotFound();
            }

            var contactoFabricante = await _context.ContactosFabricantes
                .Include(c => c.Fabricante)
                .FirstOrDefaultAsync(m => m.ContactoFabricanteId == id);
            if (contactoFabricante == null)
            {
                return NotFound();
            }

            return View(contactoFabricante);
        }

        // GET: ContactosFabricantes/Create
        public IActionResult Create()
        {
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre));
            return View();
        }

        // POST: ContactosFabricantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactoFabricanteId,FabricanteId,Nombre,Apellido,Email,Telefono,Cargo")] ContactoFabricante contactoFabricante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactoFabricante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre), contactoFabricante.FabricanteId);
            return View(contactoFabricante);
        }

        // GET: ContactosFabricantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContactosFabricantes == null)
            {
                return NotFound();
            }

            var contactoFabricante = await _context.ContactosFabricantes.FindAsync(id);
            if (contactoFabricante == null)
            {
                return NotFound();
            }
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre), contactoFabricante.FabricanteId);
            return View(contactoFabricante);
        }

        // POST: ContactosFabricantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactoFabricanteId,FabricanteId,Nombre,Apellido,Email,Telefono,Cargo")] ContactoFabricante contactoFabricante)
        {
            if (id != contactoFabricante.ContactoFabricanteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactoFabricante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoFabricanteExists(contactoFabricante.ContactoFabricanteId))
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
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre), contactoFabricante.FabricanteId);
            return View(contactoFabricante);
        }

        // GET: ContactosFabricantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContactosFabricantes == null)
            {
                return NotFound();
            }

            var contactoFabricante = await _context.ContactosFabricantes
                .Include(c => c.Fabricante)
                .FirstOrDefaultAsync(m => m.ContactoFabricanteId == id);
            if (contactoFabricante == null)
            {
                return NotFound();
            }

            return View(contactoFabricante);
        }

        // POST: ContactosFabricantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContactosFabricantes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ContactosFabricantes'  is null.");
            }
            var contactoFabricante = await _context.ContactosFabricantes.FindAsync(id);
            if (contactoFabricante != null)
            {
                _context.ContactosFabricantes.Remove(contactoFabricante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoFabricanteExists(int id)
        {
          return (_context.ContactosFabricantes?.Any(e => e.ContactoFabricanteId == id)).GetValueOrDefault();
        }
    }
}
