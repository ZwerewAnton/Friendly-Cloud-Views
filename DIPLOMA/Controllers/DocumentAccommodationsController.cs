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
    public class DocumentAccommodationsController : Controller
    {
        private readonly ApplicationDbContext_2 _context;

        public DocumentAccommodationsController(ApplicationDbContext_2 context)
        {
            _context = context;
        }

        // GET: DocumentAccommodations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext_2 = _context.Accommodation.Include(d => d.DirectoryCategoryRooms).Include(d => d.DirectoryStatusBooking).Include(d => d.DirectoryTypeRooms);
            return View(await applicationDbContext_2.ToListAsync());
        }

        // GET: DocumentAccommodations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentAccommodation = await _context.Accommodation
                .Include(d => d.DirectoryCategoryRooms)
                .Include(d => d.DirectoryStatusBooking)
                .Include(d => d.DirectoryTypeRooms)
                .FirstOrDefaultAsync(m => m.DocumentAccommodationID == id);
            if (documentAccommodation == null)
            {
                return NotFound();
            }

            return View(documentAccommodation);
        }

        // GET: DocumentAccommodations/Create
        public IActionResult Create()
        {
            ViewData["DirectoryCategoryRoomsID"] = new SelectList(_context.CategoryRooms, "DirectoryCategoryRoomsID", "CategoryRoom");
            ViewData["DirectoryStatusAccommodationID"] = new SelectList(_context.StatusAccommodation, "DirectoryStatusAccommodationID", "StatusAccommodation");
            ViewData["DirectoryTypeRoomsID"] = new SelectList(_context.TypeRooms, "DirectoryTypeRoomsID", "TypeRoom");
            return View();
        }

        // POST: DocumentAccommodations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentAccommodationID,DirectoryStatusAccommodationID,DateAccommodation,DateEviction,NumberOfPersons,FirstName,SecondName,Patronymic,PassportSerial,PassportNumber,AddressRegistration,AddressResidential,TelephoneNumber,Email,DataAboutWorkPlace,ClientDate,DirectoryCategoryRoomsID,DirectoryTypeRoomsID,NumberRoom,CostPerDay,CostTotal,Payment")] DocumentAccommodation documentAccommodation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentAccommodation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectoryCategoryRoomsID"] = new SelectList(_context.CategoryRooms, "DirectoryCategoryRoomsID", "CategoryRoom", documentAccommodation.DirectoryCategoryRoomsID);
            ViewData["DirectoryStatusAccommodationID"] = new SelectList(_context.StatusAccommodation, "DirectoryStatusAccommodationID", "StatusAccommodation", documentAccommodation.DirectoryStatusAccommodationID);
            ViewData["DirectoryTypeRoomsID"] = new SelectList(_context.TypeRooms, "DirectoryTypeRoomsID", "TypeRoom", documentAccommodation.DirectoryTypeRoomsID);
            return View(documentAccommodation);
        }

        // GET: DocumentAccommodations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentAccommodation = await _context.Accommodation.FindAsync(id);
            if (documentAccommodation == null)
            {
                return NotFound();
            }
            ViewData["DirectoryCategoryRoomsID"] = new SelectList(_context.CategoryRooms, "DirectoryCategoryRoomsID", "CategoryRoom", documentAccommodation.DirectoryCategoryRoomsID);
            ViewData["DirectoryStatusAccommodationID"] = new SelectList(_context.StatusAccommodation, "DirectoryStatusAccommodationID", "StatusAccommodation", documentAccommodation.DirectoryStatusAccommodationID);
            ViewData["DirectoryTypeRoomsID"] = new SelectList(_context.TypeRooms, "DirectoryTypeRoomsID", "TypeRoom", documentAccommodation.DirectoryTypeRoomsID);
            return View(documentAccommodation);
        }

        // POST: DocumentAccommodations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentAccommodationID,DirectoryStatusAccommodationID,DateAccommodation,DateEviction,NumberOfPersons,FirstName,SecondName,Patronymic,PassportSerial,PassportNumber,AddressRegistration,AddressResidential,TelephoneNumber,Email,DataAboutWorkPlace,ClientDate,DirectoryCategoryRoomsID,DirectoryTypeRoomsID,NumberRoom,CostPerDay,CostTotal,Payment")] DocumentAccommodation documentAccommodation)
        {
            if (id != documentAccommodation.DocumentAccommodationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentAccommodation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentAccommodationExists(documentAccommodation.DocumentAccommodationID))
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
            ViewData["DirectoryCategoryRoomsID"] = new SelectList(_context.CategoryRooms, "DirectoryCategoryRoomsID", "CategoryRoom", documentAccommodation.DirectoryCategoryRoomsID);
            ViewData["DirectoryStatusAccommodationID"] = new SelectList(_context.StatusAccommodation, "DirectoryStatusAccommodationID", "StatusAccommodation", documentAccommodation.DirectoryStatusAccommodationID);
            ViewData["DirectoryTypeRoomsID"] = new SelectList(_context.TypeRooms, "DirectoryTypeRoomsID", "TypeRoom", documentAccommodation.DirectoryTypeRoomsID);
            return View(documentAccommodation);
        }

        // GET: DocumentAccommodations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentAccommodation = await _context.Accommodation
                .Include(d => d.DirectoryCategoryRooms)
                .Include(d => d.DirectoryStatusBooking)
                .Include(d => d.DirectoryTypeRooms)
                .FirstOrDefaultAsync(m => m.DocumentAccommodationID == id);
            if (documentAccommodation == null)
            {
                return NotFound();
            }

            return View(documentAccommodation);
        }

        // POST: DocumentAccommodations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documentAccommodation = await _context.Accommodation.FindAsync(id);
            _context.Accommodation.Remove(documentAccommodation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentAccommodationExists(int id)
        {
            return _context.Accommodation.Any(e => e.DocumentAccommodationID == id);
        }
    }
}
