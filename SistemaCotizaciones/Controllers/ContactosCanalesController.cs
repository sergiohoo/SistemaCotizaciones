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
    public class ContactosCanalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactosCanalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContactosCanales
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ContactosCanales.Include(c => c.Canal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ContactosCanales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContactosCanales == null)
            {
                return NotFound();
            }

            var contactoCanal = await _context.ContactosCanales
                .Include(c => c.Canal)
                .FirstOrDefaultAsync(m => m.ContactoCanalId == id);
            if (contactoCanal == null)
            {
                return NotFound();
            }

            return View(contactoCanal);
        }

        // GET: ContactosCanales/Create
        public IActionResult Create()
        {
            ViewData["CanalId"] = new SelectList(_context.Canales, "CanalId", nameof(Canal.RazonSocial));
            return View();
        }

        // POST: ContactosCanales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactoCanalId,CanalId,Rut,Nombre,Apellido,Email,Telefono")] ContactoCanal contactoCanal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactoCanal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CanalId"] = new SelectList(_context.Canales, "CanalId", nameof(Canal.RazonSocial), contactoCanal.CanalId);
            return View(contactoCanal);
        }

        // GET: ContactosCanales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContactosCanales == null)
            {
                return NotFound();
            }

            var contactoCanal = await _context.ContactosCanales.FindAsync(id);
            if (contactoCanal == null)
            {
                return NotFound();
            }
            ViewData["CanalId"] = new SelectList(_context.Canales, "CanalId", nameof(Canal.RazonSocial), contactoCanal.CanalId);
            return View(contactoCanal);
        }

        // POST: ContactosCanales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactoCanalId,CanalId,Rut,Nombre,Apellido,Email,Telefono")] ContactoCanal contactoCanal)
        {
            if (id != contactoCanal.ContactoCanalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactoCanal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoCanalExists(contactoCanal.ContactoCanalId))
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
            ViewData["CanalId"] = new SelectList(_context.Canales, "CanalId", nameof(Canal.RazonSocial), contactoCanal.CanalId);
            return View(contactoCanal);
        }

        // GET: ContactosCanales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContactosCanales == null)
            {
                return NotFound();
            }

            var contactoCanal = await _context.ContactosCanales
                .Include(c => c.Canal)
                .FirstOrDefaultAsync(m => m.ContactoCanalId == id);
            if (contactoCanal == null)
            {
                return NotFound();
            }

            return View(contactoCanal);
        }

        // POST: ContactosCanales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContactosCanales == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ContactosCanales'  is null.");
            }
            var contactoCanal = await _context.ContactosCanales.FindAsync(id);
            if (contactoCanal != null)
            {
                _context.ContactosCanales.Remove(contactoCanal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoCanalExists(int id)
        {
          return (_context.ContactosCanales?.Any(e => e.ContactoCanalId == id)).GetValueOrDefault();
        }
    }
}
