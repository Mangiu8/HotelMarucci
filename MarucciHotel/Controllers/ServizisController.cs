using MarucciHotel.Data;
using MarucciHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MarucciHotel.Controllers
{
    public class ServizisController : Controller
    {
        private readonly MarucciHotelContext _context;

        public ServizisController(MarucciHotelContext context)
        {
            _context = context;
        }

        // GET: Servizis
        public async Task<IActionResult> Index()
        {
            var marucciHotelContext = _context.Servizi.Include(s => s.Prenotazione);
            return View(await marucciHotelContext.ToListAsync());
        }

        // GET: Servizis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servizi = await _context.Servizi
                .Include(s => s.Prenotazione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (servizi == null)
            {
                return NotFound();
            }

            return View(servizi);
        }
        public IActionResult Create(int id)
        {
            ViewBag.IDPrenotazione = id;
            ViewData["IDPrenotazione"] = new SelectList(_context.Prenotazione, "ID", "ID");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descrizione,Prezzo,DataRichiestaServizio,IDPrenotazione")] Servizi servizi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servizi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDPrenotazione"] = new SelectList(_context.Prenotazione, "ID", "ID", servizi.IDPrenotazione);
            return View(servizi);
        }

        // GET: Servizis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servizi = await _context.Servizi.FindAsync(id);
            if (servizi == null)
            {
                return NotFound();
            }
            ViewData["IDPrenotazione"] = new SelectList(_context.Prenotazione, "ID", "ID", servizi.IDPrenotazione);
            return View(servizi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descrizione,Prezzo,DataRichiestaServizio,IDPrenotazione")] Servizi servizi)
        {
            if (id != servizi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servizi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiziExists(servizi.ID))
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
            ViewData["IDPrenotazione"] = new SelectList(_context.Prenotazione, "ID", "ID", servizi.IDPrenotazione);
            return View(servizi);
        }

        // GET: Servizis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servizi = await _context.Servizi
                .Include(s => s.Prenotazione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (servizi == null)
            {
                return NotFound();
            }

            return View(servizi);
        }

        // POST: Servizis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servizi = await _context.Servizi.FindAsync(id);
            if (servizi != null)
            {
                _context.Servizi.Remove(servizi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiziExists(int id)
        {
            return _context.Servizi.Any(e => e.ID == id);
        }
    }
}
