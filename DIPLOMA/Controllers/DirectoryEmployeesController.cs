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
    public class DirectoryEmployeesController : Controller
    {
        private readonly ApplicationDbContext_2 _context;

        public DirectoryEmployeesController(ApplicationDbContext_2 context)
        {
            _context = context;
        }

        // GET: DirectoryEmployees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext_2 = _context.Employees.Include(d => d.DirectoryServices);
            return View(await applicationDbContext_2.ToListAsync());
        }

        // GET: DirectoryEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryEmployees = await _context.Employees
                .Include(d => d.DirectoryServices)
                .FirstOrDefaultAsync(m => m.DirectoryEmployeesID == id);
            if (directoryEmployees == null)
            {
                return NotFound();
            }

            return View(directoryEmployees);
        }

        // GET: DirectoryEmployees/Create
        public IActionResult Create()
        {
            ViewData["DirectoryServicesID"] = new SelectList(_context.Services, "DirectoryServicesID", "Service");
            return View();
        }

        // POST: DirectoryEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirectoryEmployeesID,FirstName,SecondName,Patronymic,PassportSerial,PassportNumber,AddressRegistration,AddressResidential,MaritalStatus,TelephoneNumber,Education,Email,DirectoryServicesID,EmployeeDate")] DirectoryEmployees directoryEmployees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directoryEmployees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectoryServicesID"] = new SelectList(_context.Services, "DirectoryServicesID", "Service", directoryEmployees.DirectoryServicesID);
            return View(directoryEmployees);
        }

        // GET: DirectoryEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryEmployees = await _context.Employees.FindAsync(id);
            if (directoryEmployees == null)
            {
                return NotFound();
            }
            ViewData["DirectoryServicesID"] = new SelectList(_context.Services, "DirectoryServicesID", "Service", directoryEmployees.DirectoryServicesID);
            return View(directoryEmployees);
        }

        // POST: DirectoryEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DirectoryEmployeesID,FirstName,SecondName,Patronymic,PassportSerial,PassportNumber,AddressRegistration,AddressResidential,MaritalStatus,TelephoneNumber,Education,Email,DirectoryServicesID,EmployeeDate")] DirectoryEmployees directoryEmployees)
        {
            if (id != directoryEmployees.DirectoryEmployeesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directoryEmployees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectoryEmployeesExists(directoryEmployees.DirectoryEmployeesID))
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
            ViewData["DirectoryServicesID"] = new SelectList(_context.Services, "DirectoryServicesID", "Service", directoryEmployees.DirectoryServicesID);
            return View(directoryEmployees);
        }

        // GET: DirectoryEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryEmployees = await _context.Employees
                .Include(d => d.DirectoryServices)
                .FirstOrDefaultAsync(m => m.DirectoryEmployeesID == id);
            if (directoryEmployees == null)
            {
                return NotFound();
            }

            return View(directoryEmployees);
        }

        // POST: DirectoryEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directoryEmployees = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(directoryEmployees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectoryEmployeesExists(int id)
        {
            return _context.Employees.Any(e => e.DirectoryEmployeesID == id);
        }
    }
}
