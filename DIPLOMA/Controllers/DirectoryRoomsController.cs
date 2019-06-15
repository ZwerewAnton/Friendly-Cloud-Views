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
    public class DirectoryRoomsController : Controller
    {
        private readonly ApplicationDbContext_2 _context;

        public DirectoryRoomsController(ApplicationDbContext_2 context)
        {
            _context = context;
        }

        // GET: DirectoryRooms
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CostPerDay"] = String.IsNullOrEmpty(sortOrder) ? "costPD_desc" : "";
            ViewData["SecondName"] = sortOrder == "Sname" ? "sname_desc" : "Sname";
            ViewData["Patronymic"] = sortOrder == "Patronymic" ? "patronymic_desc" : "Patronymic";
            ViewData["ClientDate"] = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var clients = from s in _context.Clients
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(s => s.FirstName.Contains(searchString)
                                        || s.SecondName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "costPD_desc":
                    clients = clients.OrderByDescending(s => s.FirstName);
                    break;
                case "sname_desc":
                    clients = clients.OrderByDescending(s => s.SecondName);
                    break;
                case "patronymic_desc":
                    clients = clients.OrderByDescending(s => s.Patronymic);
                    break;
                case "Sname":
                    clients = clients.OrderBy(s => s.SecondName);
                    break;
                case "Patronymic":
                    clients = clients.OrderBy(s => s.Patronymic);
                    break;
                case "Date":
                    clients = clients.OrderBy(s => s.ClientDate);
                    break;
                case "date_desc":
                    clients = clients.OrderByDescending(s => s.ClientDate);
                    break;
                default:
                    clients = clients.OrderBy(s => s.FirstName);
                    break;
            }


                var applicationDbContext_2 = _context.Rooms.Include(d => d.DirectoryCategoryRooms).Include(d => d.DirectoryStatusRooms).Include(d => d.DirectoryTypeRooms);
            return View(await applicationDbContext_2.ToListAsync());
        }

        // GET: DirectoryRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryRooms = await _context.Rooms
                .Include(d => d.DirectoryCategoryRooms)
                .Include(d => d.DirectoryStatusRooms)
                .Include(d => d.DirectoryTypeRooms)
                .FirstOrDefaultAsync(m => m.DirectoryRoomsID == id);
            if (directoryRooms == null)
            {
                return NotFound();
            }

            return View(directoryRooms);
        }

        // GET: DirectoryRooms/Create
        public IActionResult Create()
        {
            ViewData["DirectoryCategoryRoomsID"] = new SelectList(_context.CategoryRooms, "DirectoryCategoryRoomsID", "CategoryRoom");
            ViewData["DirectoryStatusRoomsID"] = new SelectList(_context.StatusRooms, "DirectoryStatusRoomsID", "StatusRoom");
            ViewData["DirectoryTypeRoomsID"] = new SelectList(_context.TypeRooms, "DirectoryTypeRoomsID", "TypeRoom");
            return View();
        }

        // POST: DirectoryRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirectoryRoomsID,DirectoryCategoryRoomsID,DirectoryTypeRoomsID,DirectoryStatusRoomsID,CostPerDay,NumberRoom")] DirectoryRooms directoryRooms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directoryRooms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectoryCategoryRoomsID"] = new SelectList(_context.CategoryRooms, "DirectoryCategoryRoomsID", "CategoryRoom", directoryRooms.DirectoryCategoryRoomsID);
            ViewData["DirectoryStatusRoomsID"] = new SelectList(_context.StatusRooms, "DirectoryStatusRoomsID", "StatusRoom", directoryRooms.DirectoryStatusRoomsID);
            ViewData["DirectoryTypeRoomsID"] = new SelectList(_context.TypeRooms, "DirectoryTypeRoomsID", "TypeRoom", directoryRooms.DirectoryTypeRoomsID);
            return View(directoryRooms);
        }

        // GET: DirectoryRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryRooms = await _context.Rooms.FindAsync(id);
            if (directoryRooms == null)
            {
                return NotFound();
            }
            ViewData["DirectoryCategoryRoomsID"] = new SelectList(_context.CategoryRooms, "DirectoryCategoryRoomsID", "CategoryRoom", directoryRooms.DirectoryCategoryRoomsID);
            ViewData["DirectoryStatusRoomsID"] = new SelectList(_context.StatusRooms, "DirectoryStatusRoomsID", "StatusRoom", directoryRooms.DirectoryStatusRoomsID);
            ViewData["DirectoryTypeRoomsID"] = new SelectList(_context.TypeRooms, "DirectoryTypeRoomsID", "TypeRoom", directoryRooms.DirectoryTypeRoomsID);
            return View(directoryRooms);
        }

        // POST: DirectoryRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DirectoryRoomsID,DirectoryCategoryRoomsID,DirectoryTypeRoomsID,DirectoryStatusRoomsID,CostPerDay,NumberRoom")] DirectoryRooms directoryRooms)
        {
            if (id != directoryRooms.DirectoryRoomsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directoryRooms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectoryRoomsExists(directoryRooms.DirectoryRoomsID))
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
            ViewData["DirectoryCategoryRoomsID"] = new SelectList(_context.CategoryRooms, "DirectoryCategoryRoomsID", "CategoryRoom", directoryRooms.DirectoryCategoryRoomsID);
            ViewData["DirectoryStatusRoomsID"] = new SelectList(_context.StatusRooms, "DirectoryStatusRoomsID", "StatusRoom", directoryRooms.DirectoryStatusRoomsID);
            ViewData["DirectoryTypeRoomsID"] = new SelectList(_context.TypeRooms, "DirectoryTypeRoomsID", "TypeRoom", directoryRooms.DirectoryTypeRoomsID);
            return View(directoryRooms);
        }

        // GET: DirectoryRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryRooms = await _context.Rooms
                .Include(d => d.DirectoryCategoryRooms)
                .Include(d => d.DirectoryStatusRooms)
                .Include(d => d.DirectoryTypeRooms)
                .FirstOrDefaultAsync(m => m.DirectoryRoomsID == id);
            if (directoryRooms == null)
            {
                return NotFound();
            }

            return View(directoryRooms);
        }

        // POST: DirectoryRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directoryRooms = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(directoryRooms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectoryRoomsExists(int id)
        {
            return _context.Rooms.Any(e => e.DirectoryRoomsID == id);
        }
    }
}
