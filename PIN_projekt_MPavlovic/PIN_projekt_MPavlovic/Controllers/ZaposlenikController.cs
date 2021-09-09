using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIN_projekt_MPavlovic.Models;


namespace PIN_projekt_MPavlovic.Controllers
{
    public class ZaposlenikController : Controller
    {
        private readonly Zaposlenici _context;

        public ZaposlenikController(Zaposlenici context)
        {
            _context = context;
        }

        // GET: Zaposlenik
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zaposlenik.ToListAsync());
        }

        // GET: Zaposlenik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zapo = await _context.Zaposlenik
                .FirstOrDefaultAsync(m => m.ZaposlenikID == id);
            if (zapo == null)
            {
                return NotFound();
            }

            return View(zapo);
        }

        // GET: Zaposlenik/Create
        public IActionResult Dodaj(int id=0)
        {
            if(id==0)
            return View(new Zapo());
            else
                return View(_context.Zaposlenik.Find(id));
        }

        // POST: Zaposlenik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Dodaj([Bind("ZaposlenikID,Ime,Prezime,Zvanje,Lokacija")] Zapo zapo)
        {
            if (ModelState.IsValid)
            {
                if(zapo.ZaposlenikID==0)
                _context.Add(zapo);
                else
                    _context.Update(zapo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zapo);
        }

        // GET: Zaposlenik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zapo = await _context.Zaposlenik.FindAsync(id);
            if (zapo == null)
            {
                return NotFound();
            }
            return View(zapo);
        }

        // POST: Zaposlenik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZaposlenikID,Ime,Prezime,Zvanje,Lokacija")] Zapo zapo)
        {
            if (id != zapo.ZaposlenikID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zapo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZapoExists(zapo.ZaposlenikID))
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
            return View(zapo);
        }

        // GET: Zaposlenik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zapo = await _context.Zaposlenik
                .FirstOrDefaultAsync(m => m.ZaposlenikID == id);
            if (zapo == null)
            {
                return NotFound();
            }

            return View(zapo);
        }

        // POST: Zaposlenik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zapo = await _context.Zaposlenik.FindAsync(id);
            _context.Zaposlenik.Remove(zapo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZapoExists(int id)
        {
            return _context.Zaposlenik.Any(e => e.ZaposlenikID == id);
        }
    }
}
