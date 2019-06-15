using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DIPLOMA.Data;
using DIPLOMA.Models;

namespace DIPLOMA.Controllers
{
    public class DirectoryStatusAccommodationsController : Controller
    {
        private readonly ApplicationDbContext_2 _context;

        public DirectoryStatusAccommodationsController(ApplicationDbContext_2 context)
        {
            _context = context;
        }

        // GET: DirectoryStatusAccommodations
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusAccommodation.ToListAsync());
        }

        // GET: DirectoryStatusAccommodations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryStatusAccommodation = await _context.StatusAccommodation
                .FirstOrDefaultAsync(m => m.DirectoryStatusAccommodationID == id);
            if (directoryStatusAccommodation == null)
            {
                return NotFound();
            }

            return View(directoryStatusAccommodation);
        }

        // GET: DirectoryStatusAccommodations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DirectoryStatusAccommodations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirectoryStatusAccommodationID,StatusAccommodation")] DirectoryStatusAccommodation directoryStatusAccommodation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directoryStatusAccommodation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(directoryStatusAccommodation);
        }

        // GET: DirectoryStatusAccommodations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryStatusAccommodation = await _context.StatusAccommodation.FindAsync(id);
            if (directoryStatusAccommodation == null)
            {
                return NotFound();
            }
            return View(directoryStatusAccommodation);
        }

        // POST: DirectoryStatusAccommodations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DirectoryStatusAccommodationID,StatusAccommodation")] DirectoryStatusAccommodation directoryStatusAccommodation)
        {
            if (id != directoryStatusAccommodation.DirectoryStatusAccommodationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directoryStatusAccommodation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectoryStatusAccommodationExists(directoryStatusAccommodation.DirectoryStatusAccommodationID))
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
            return View(directoryStatusAccommodation);
        }

        // GET: DirectoryStatusAccommodations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryStatusAccommodation = await _context.StatusAccommodation
                .FirstOrDefaultAsync(m => m.DirectoryStatusAccommodationID == id);
            if (directoryStatusAccommodation == null)
            {
                return NotFound();
            }

            return View(directoryStatusAccommodation);
        }

        // POST: DirectoryStatusAccommodations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directoryStatusAccommodation = await _context.StatusAccommodation.FindAsync(id);
            _context.StatusAccommodation.Remove(directoryStatusAccommodation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectoryStatusAccommodationExists(int id)
        {
            return _context.StatusAccommodation.Any(e => e.DirectoryStatusAccommodationID == id);
        }
    }
}
