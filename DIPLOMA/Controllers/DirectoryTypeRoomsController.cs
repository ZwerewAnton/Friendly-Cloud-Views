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
    public class DirectoryTypeRoomsController : Controller
    {
        private readonly ApplicationDbContext_2 _context;

        public DirectoryTypeRoomsController(ApplicationDbContext_2 context)
        {
            _context = context;
        }

        // GET: DirectoryTypeRooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeRooms.ToListAsync());
        }

        // GET: DirectoryTypeRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryTypeRooms = await _context.TypeRooms
                .FirstOrDefaultAsync(m => m.DirectoryTypeRoomsID == id);
            if (directoryTypeRooms == null)
            {
                return NotFound();
            }

            return View(directoryTypeRooms);
        }

        // GET: DirectoryTypeRooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DirectoryTypeRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirectoryTypeRoomsID,TypeRoom")] DirectoryTypeRooms directoryTypeRooms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directoryTypeRooms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(directoryTypeRooms);
        }

        // GET: DirectoryTypeRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryTypeRooms = await _context.TypeRooms.FindAsync(id);
            if (directoryTypeRooms == null)
            {
                return NotFound();
            }
            return View(directoryTypeRooms);
        }

        // POST: DirectoryTypeRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DirectoryTypeRoomsID,TypeRoom")] DirectoryTypeRooms directoryTypeRooms)
        {
            if (id != directoryTypeRooms.DirectoryTypeRoomsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directoryTypeRooms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectoryTypeRoomsExists(directoryTypeRooms.DirectoryTypeRoomsID))
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
            return View(directoryTypeRooms);
        }

        // GET: DirectoryTypeRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryTypeRooms = await _context.TypeRooms
                .FirstOrDefaultAsync(m => m.DirectoryTypeRoomsID == id);
            if (directoryTypeRooms == null)
            {
                return NotFound();
            }

            return View(directoryTypeRooms);
        }

        // POST: DirectoryTypeRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directoryTypeRooms = await _context.TypeRooms.FindAsync(id);
            _context.TypeRooms.Remove(directoryTypeRooms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectoryTypeRoomsExists(int id)
        {
            return _context.TypeRooms.Any(e => e.DirectoryTypeRoomsID == id);
        }
    }
}
