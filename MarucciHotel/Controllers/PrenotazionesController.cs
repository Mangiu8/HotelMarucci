using MarucciHotel.Data;
using MarucciHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MarucciHotel.Controllers
{
    public class PrenotazionesController : Controller
    {
        private readonly MarucciHotelContext _context;

        public PrenotazionesController(MarucciHotelContext context)
        {
            _context = context;
        }

        // GET: Prenotaziones
        public async Task<IActionResult> Index()
        {
            var marucciHotelContext = _context.Prenotazione.Include(p => p.Camera).Include(p => p.Cliente).Include(p => p.Pensione);
            return View(await marucciHotelContext.ToListAsync());
        }

        // GET: Prenotaziones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazione
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            return View(prenotazione);
        }

        // GET: Prenotaziones/Create
        public IActionResult Create()
        {
            ViewData["IDCamera"] = new SelectList(_context.Camera, "ID", "Descrizione");
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "ID", "Cognome");
            ViewData["IDPensione"] = new SelectList(_context.Pensione, "ID", "Tipologia");
            return View();
        }

        // POST: Prenotaziones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DataPrenotazione,DataInizioSoggiorno,DataFineSoggiorno,Anno,Acconto,Prezzo,IDCliente,IDCamera,IDPensione")] Prenotazione prenotazione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prenotazione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDCamera"] = new SelectList(_context.Camera, "ID", "Descrizione", prenotazione.IDCamera);
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "ID", "Cognome", prenotazione.IDCliente);
            ViewData["IDPensione"] = new SelectList(_context.Pensione, "ID", "Tipologia", prenotazione.IDPensione);
            return View(prenotazione);
        }

        // GET: Prenotaziones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazione.FindAsync(id);
            if (prenotazione == null)
            {
                return NotFound();
            }
            ViewData["IDCamera"] = new SelectList(_context.Camera, "ID", "Descrizione", prenotazione.IDCamera);
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "ID", "Cognome", prenotazione.IDCliente);
            ViewData["IDPensione"] = new SelectList(_context.Pensione, "ID", "Tipologia", prenotazione.IDPensione);
            return View(prenotazione);
        }

        // POST: Prenotaziones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DataPrenotazione,DataInizioSoggiorno,DataFineSoggiorno,Anno,Acconto,Prezzo,IDCliente,IDCamera,IDPensione")] Prenotazione prenotazione)
        {
            if (id != prenotazione.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prenotazione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrenotazioneExists(prenotazione.ID))
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
            ViewData["IDCamera"] = new SelectList(_context.Camera, "ID", "Descrizione", prenotazione.IDCamera);
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "ID", "Cognome", prenotazione.IDCliente);
            ViewData["IDPensione"] = new SelectList(_context.Pensione, "ID", "Tipologia", prenotazione.IDPensione);
            return View(prenotazione);
        }

        // GET: Prenotaziones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazione
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            return View(prenotazione);
        }

        // POST: Prenotaziones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prenotazione = await _context.Prenotazione.FindAsync(id);
            if (prenotazione != null)
            {
                _context.Prenotazione.Remove(prenotazione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrenotazioneExists(int id)
        {
            return _context.Prenotazione.Any(e => e.ID == id);
        }
        [HttpGet]
        public async Task<IActionResult> SearchByCodiceFiscale(string codiceFiscale)
        {
            if (string.IsNullOrEmpty(codiceFiscale))
            {
                return BadRequest("Il codice fiscale è obbligatorio");
            }

            var cliente = await _context.Clienti.FirstOrDefaultAsync(c => c.Cod_Fisc == codiceFiscale);

            if (cliente == null)
            {
                return NotFound("Cliente non trovato");
            }

            var prenotazioni = await _context.Prenotazione
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .Where(p => p.IDCliente == cliente.ID)
                .ToListAsync();

            return View(prenotazioni);
        }
        [HttpGet]
        public async Task<IActionResult> TotalPensioneCompleta()
        {
            var pensioneCompleta = await _context.Pensione.FirstOrDefaultAsync(p => p.Tipologia == "Pensione Completa");

            if (pensioneCompleta == null)
            {
                TempData["Message3"] = "Nessuna pensione completa trovata";
                return RedirectToAction("Index");
            }

            var totalPrenotazioni = await _context.Prenotazione
                .Where(p => p.IDPensione == pensioneCompleta.ID)
                .CountAsync();

            return View(totalPrenotazioni);
        }
        public async Task<IActionResult> Checkout(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazione
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            var servizi = await _context.Servizi
                .Where(s => s.IDPrenotazione == id)
                .ToListAsync();


            var model = new CheckoutView
            {
                Prenotazione = prenotazione,
                Servizi = servizi
            };

            return View(model);
        }
    }
}
