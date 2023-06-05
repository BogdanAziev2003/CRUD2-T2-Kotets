using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD2.Data;
using CRUD2.Models;

namespace CRUD2.Controllers
{
    public class Children1Controller : Controller
    {
        private readonly CRUD2Context _context;

        public Children1Controller(CRUD2Context context)
        {
            _context = context;
        }

        // GET: Children1
        public async Task<IActionResult> Index()
        {
              return _context.Child != null ? 
                          View(await _context.Child.ToListAsync()) :
                          Problem("Entity set 'CRUD2Context.Child'  is null.");
        }

        // GET: Children1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Child == null)
            {
                return NotFound();
            }

            var child = await _context.Child
                .FirstOrDefaultAsync(m => m.Id == id);
            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        // GET: Children1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Children1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,BirthDate")] Child child)
        {
            if (ModelState.IsValid)
            {
                _context.Add(child);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(child);
        }

        // GET: Children1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Child == null)
            {
                return NotFound();
            }

            var child = await _context.Child.FindAsync(id);
            if (child == null)
            {
                return NotFound();
            }
            return View(child);
        }

        // POST: Children1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,BirthDate")] Child child)
        {
            if (id != child.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(child);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChildExists(child.Id))
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
            return View(child);
        }

        // GET: Children1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Child == null)
            {
                return NotFound();
            }

            var child = await _context.Child
                .FirstOrDefaultAsync(m => m.Id == id);
            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        // POST: Children1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Child == null)
            {
                return Problem("Entity set 'CRUD2Context.Child'  is null.");
            }
            var child = await _context.Child.FindAsync(id);
            if (child != null)
            {
                _context.Child.Remove(child);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChildExists(int id)
        {
          return (_context.Child?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
