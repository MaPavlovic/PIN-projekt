using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIN_projekt_MPavlovic.Data;
using PIN_projekt_MPavlovic.Models;
using Microsoft.AspNetCore.Authorization;

namespace PIN_projekt_MPavlovic.Controllers
{
    public class ProizvodisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProizvodisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proizvodis
        //public IActionResult Index(string search, Proizvodi proiz)
        //{
        //    if(String.IsNullOrEmpty(search))
        //    {
        //        var Proizvodis = from Proizvodi in _context.Proizvodi select Proizvodi;
        //        Proizvodis = Proizvodis.Where(l => l.Naziv.StartsWith(search));
        //        return View(Proizvodis.ToList());

        //    }
        //    //var p = _context.Proizvodi.Where(m => m.Naziv.StartsWith(search)).ToList();
        //    //Proizvodi pr = _context.Proizvodi.Where(k => k.id == proiz.id).FirstOrDefault();

        //    //return View("Index", p);
        //}

        public async Task<IActionResult> Index(string search)
        {
            if(!String.IsNullOrEmpty(search))
            {
                var Proizvodis = from Proizvodi in _context.Proizvodi select Proizvodi;
                Proizvodis = Proizvodis.Where(l => l.Naziv.StartsWith(search));
                return View(Proizvodis.ToList());

            }

            return View(await _context.Proizvodi.ToListAsync());
        }

        // GET: Proizvodis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvodi = await _context.Proizvodi
                .FirstOrDefaultAsync(m => m.id == id);
            if (proizvodi == null)
            {
                return NotFound();
            }

            return View(proizvodi);
        }

        // GET: Proizvodis/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proizvodis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Naziv,Cijena")] Proizvodi proizvodi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proizvodi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proizvodi);
        }

        // GET: Proizvodis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvodi = await _context.Proizvodi.FindAsync(id);
            if (proizvodi == null)
            {
                return NotFound();
            }
            return View(proizvodi);
        }

        // POST: Proizvodis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Naziv,Cijena")] Proizvodi proizvodi)
        {
            if (id != proizvodi.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proizvodi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProizvodiExists(proizvodi.id))
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
            return View(proizvodi);
        }

        // GET: Proizvodis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvodi = await _context.Proizvodi
                .FirstOrDefaultAsync(m => m.id == id);
            if (proizvodi == null)
            {
                return NotFound();
            }

            return View(proizvodi);
        }

        // POST: Proizvodis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proizvodi = await _context.Proizvodi.FindAsync(id);
            _context.Proizvodi.Remove(proizvodi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProizvodiExists(int id)
        {
            return _context.Proizvodi.Any(e => e.id == id);
        }
    }
}
