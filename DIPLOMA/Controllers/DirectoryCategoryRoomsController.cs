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
    public class DirectoryCategoryRoomsController : Controller
    {
        private readonly ApplicationDbContext_2 _context;

        public DirectoryCategoryRoomsController(ApplicationDbContext_2 context)
        {
            _context = context;
        }

        // GET: DirectoryCategoryRooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoryRooms.ToListAsync());
        }

        // GET: DirectoryCategoryRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryCategoryRooms = await _context.CategoryRooms
                .FirstOrDefaultAsync(m => m.DirectoryCategoryRoomsID == id);
            if (directoryCategoryRooms == null)
            {
                return NotFound();
            }

            return View(directoryCategoryRooms);
        }

        // GET: DirectoryCategoryRooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DirectoryCategoryRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirectoryCategoryRoomsID,CategoryRoom")] DirectoryCategoryRooms directoryCategoryRooms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directoryCategoryRooms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(directoryCategoryRooms);
        }

        // GET: DirectoryCategoryRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryCategoryRooms = await _context.CategoryRooms.FindAsync(id);
            if (directoryCategoryRooms == null)
            {
                return NotFound();
            }
            return View(directoryCategoryRooms);
        }

        // POST: DirectoryCategoryRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DirectoryCategoryRoomsID,CategoryRoom")] DirectoryCategoryRooms directoryCategoryRooms)
        {
            if (id != directoryCategoryRooms.DirectoryCategoryRoomsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directoryCategoryRooms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectoryCategoryRoomsExists(directoryCategoryRooms.DirectoryCategoryRoomsID))
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
            return View(directoryCategoryRooms);
        }

        // GET: DirectoryCategoryRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryCategoryRooms = await _context.CategoryRooms
                .FirstOrDefaultAsync(m => m.DirectoryCategoryRoomsID == id);
            if (directoryCategoryRooms == null)
            {
                return NotFound();
            }

            return View(directoryCategoryRooms);
        }

        // POST: DirectoryCategoryRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directoryCategoryRooms = await _context.CategoryRooms.FindAsync(id);
            _context.CategoryRooms.Remove(directoryCategoryRooms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectoryCategoryRoomsExists(int id)
        {
            return _context.CategoryRooms.Any(e => e.DirectoryCategoryRoomsID == id);
        }
    }
}
