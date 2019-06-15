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
    public class DirectoryServicesController : Controller
    {
        private readonly ApplicationDbContext_2 _context;

        public DirectoryServicesController(ApplicationDbContext_2 context)
        {
            _context = context;
        }

        // GET: DirectoryServices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Services.ToListAsync());
        }

        // GET: DirectoryServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryServices = await _context.Services
                .FirstOrDefaultAsync(m => m.DirectoryServicesID == id);
            if (directoryServices == null)
            {
                return NotFound();
            }

            return View(directoryServices);
        }

        // GET: DirectoryServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DirectoryServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirectoryServicesID,Service")] DirectoryServices directoryServices)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directoryServices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(directoryServices);
        }

        // GET: DirectoryServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryServices = await _context.Services.FindAsync(id);
            if (directoryServices == null)
            {
                return NotFound();
            }
            return View(directoryServices);
        }

        // POST: DirectoryServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DirectoryServicesID,Service")] DirectoryServices directoryServices)
        {
            if (id != directoryServices.DirectoryServicesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directoryServices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectoryServicesExists(directoryServices.DirectoryServicesID))
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
            return View(directoryServices);
        }

        // GET: DirectoryServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryServices = await _context.Services
                .FirstOrDefaultAsync(m => m.DirectoryServicesID == id);
            if (directoryServices == null)
            {
                return NotFound();
            }

            return View(directoryServices);
        }

        // POST: DirectoryServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directoryServices = await _context.Services.FindAsync(id);
            _context.Services.Remove(directoryServices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectoryServicesExists(int id)
        {
            return _context.Services.Any(e => e.DirectoryServicesID == id);
        }
    }
}
