using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Market.Data;
using Market.Models;

namespace Market.Controllers
{
    public class WhishListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WhishListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WhishList
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WhishLists.Include(w => w.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WhishList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WhishLists == null)
            {
                return NotFound();
            }

            var whishList = await _context.WhishLists
                .Include(w => w.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whishList == null)
            {
                return NotFound();
            }

            return View(whishList);
        }

        // GET: WhishList/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Products, "Id", "Name");
            return View();
        }

        // POST: WhishList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] WhishList whishList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(whishList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Products, "Id", "Name", whishList.Id);
            return View(whishList);
        }

        // GET: WhishList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WhishLists == null)
            {
                return NotFound();
            }

            var whishList = await _context.WhishLists.FindAsync(id);
            if (whishList == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Products, "Id", "Name", whishList.Id);
            return View(whishList);
        }

        // POST: WhishList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] WhishList whishList)
        {
            if (id != whishList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(whishList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhishListExists(whishList.Id))
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
            ViewData["Id"] = new SelectList(_context.Products, "Id", "Name", whishList.Id);
            return View(whishList);
        }

        // GET: WhishList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WhishLists == null)
            {
                return NotFound();
            }

            var whishList = await _context.WhishLists
                .Include(w => w.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whishList == null)
            {
                return NotFound();
            }

            return View(whishList);
        }

        // POST: WhishList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WhishLists == null)
            {
                return Problem("Entity set 'ApplicationDbContext.WhishLists'  is null.");
            }
            var whishList = await _context.WhishLists.FindAsync(id);
            if (whishList != null)
            {
                _context.WhishLists.Remove(whishList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhishListExists(int id)
        {
          return _context.WhishLists.Any(e => e.Id == id);
        }
    }
}
