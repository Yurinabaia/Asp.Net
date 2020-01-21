using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Controllers
{
    public class DepartamantsController : Controller
    {
        private readonly SalesWebMVCContext _context;

        public DepartamantsController(SalesWebMVCContext context)
        {
            _context = context;
        }

        // GET: Departamants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departamants.ToListAsync());
        }

        // GET: Departamants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamants = await _context.Departamants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamants == null)
            {
                return NotFound();
            }

            return View(departamants);
        }

        // GET: Departamants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Departamants departamants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departamants);
        }

        // GET: Departamants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamants = await _context.Departamants.FindAsync(id);
            if (departamants == null)
            {
                return NotFound();
            }
            return View(departamants);
        }

        // POST: Departamants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Departamants departamants)
        {
            if (id != departamants.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamantsExists(departamants.Id))
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
            return View(departamants);
        }

        // GET: Departamants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamants = await _context.Departamants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamants == null)
            {
                return NotFound();
            }

            return View(departamants);
        }

        // POST: Departamants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamants = await _context.Departamants.FindAsync(id);
            _context.Departamants.Remove(departamants);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamantsExists(int id)
        {
            return _context.Departamants.Any(e => e.Id == id);
        }
        
    }
}
