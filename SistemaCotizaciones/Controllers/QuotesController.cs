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
    public class QuotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Quotes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Quotes.Include(q => q.ContactoFabricante).Include(q => q.Fabricante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Quotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Quotes == null)
            {
                return NotFound();
            }

            var quote = await _context.Quotes
                .Include(q => q.ContactoFabricante)
                .Include(q => q.Fabricante)
                .FirstOrDefaultAsync(m => m.QuoteId == id);
            if (quote == null)
            {
                return NotFound();
            }

            return View(quote);
        }

        // GET: Quotes/Create
        public IActionResult Create()
        {
            ViewData["ContactoFabricanteId"] = new SelectList(_context.ContactosFabricantes, "ContactoFabricanteId", nameof(ContactoFabricante.Nombre));
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre));
            return View();
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuoteId,FabricanteId,ContactoFabricanteId,NumeroQuote,NombreOportunidad,Vigencia,FechaEmision")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactoFabricanteId"] = new SelectList(_context.ContactosFabricantes, "ContactoFabricanteId", nameof(ContactoFabricante.Nombre), quote.ContactoFabricanteId);
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre), quote.FabricanteId);
            return View(quote);
        }

        // GET: Quotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Quotes == null)
            {
                return NotFound();
            }

            var quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }
            ViewData["ContactoFabricanteId"] = new SelectList(_context.ContactosFabricantes, "ContactoFabricanteId", nameof(ContactoFabricante.Nombre), quote.ContactoFabricanteId);
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre), quote.FabricanteId);
            return View(quote);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuoteId,FabricanteId,ContactoFabricanteId,NumeroQuote,NombreOportunidad,Vigencia,FechaEmision")] Quote quote)
        {
            if (id != quote.QuoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuoteExists(quote.QuoteId))
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
            ViewData["ContactoFabricanteId"] = new SelectList(_context.ContactosFabricantes, "ContactoFabricanteId", nameof(ContactoFabricante.Nombre), quote.ContactoFabricanteId);
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre), quote.FabricanteId);
            return View(quote);
        }

        // GET: Quotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Quotes == null)
            {
                return NotFound();
            }

            var quote = await _context.Quotes
                .Include(q => q.ContactoFabricante)
                .Include(q => q.Fabricante)
                .FirstOrDefaultAsync(m => m.QuoteId == id);
            if (quote == null)
            {
                return NotFound();
            }

            return View(quote);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Quotes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Quotes'  is null.");
            }
            var quote = await _context.Quotes.FindAsync(id);
            if (quote != null)
            {
                _context.Quotes.Remove(quote);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuoteExists(int id)
        {
          return (_context.Quotes?.Any(e => e.QuoteId == id)).GetValueOrDefault();
        }
    }
}
