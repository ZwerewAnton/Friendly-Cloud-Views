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
    public class DirectoryClientsController : Controller
    {
        private readonly ApplicationDbContext_2 _context;

        public DirectoryClientsController(ApplicationDbContext_2 context)
        {
            _context = context;
        }

        // GET: DirectoryClients
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["FirstName"] = String.IsNullOrEmpty(sortOrder) ? "fname_desc" : "";
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
                case "fname_desc":
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
            int pageSize = 3;
            return View(await PaginatedList<DirectoryClients>.CreateAsync(clients.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View(await clients.AsNoTracking().ToListAsync());
            //return View(await _context.Clients.ToListAsync());
        }

        // GET: DirectoryClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryClients = await _context.Clients
                .FirstOrDefaultAsync(m => m.DirectoryClientsID == id);
            if (directoryClients == null)
            {
                return NotFound();
            }

            return View(directoryClients);
        }

        // GET: DirectoryClients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DirectoryClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirectoryClientsID,FirstName,SecondName,Patronymic,ClientDate,PassportSerial,PassportNumber,AddressRegistration,AddressResidential,TelephoneNumber,Email,DataAboutWorkPlace")] DirectoryClients directoryClients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directoryClients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(directoryClients);
        }

        // GET: DirectoryClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryClients = await _context.Clients.FindAsync(id);
            if (directoryClients == null)
            {
                return NotFound();
            }
            return View(directoryClients);
        }

        // POST: DirectoryClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DirectoryClientsID,FirstName,SecondName,Patronymic,ClientDate,PassportSerial,PassportNumber,AddressRegistration,AddressResidential,TelephoneNumber,Email,DataAboutWorkPlace")] DirectoryClients directoryClients)
        {
            if (id != directoryClients.DirectoryClientsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directoryClients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectoryClientsExists(directoryClients.DirectoryClientsID))
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
            return View(directoryClients);
        }

        // GET: DirectoryClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directoryClients = await _context.Clients
                .FirstOrDefaultAsync(m => m.DirectoryClientsID == id);
            if (directoryClients == null)
            {
                return NotFound();
            }

            return View(directoryClients);
        }

        // POST: DirectoryClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directoryClients = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(directoryClients);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectoryClientsExists(int id)
        {
            return _context.Clients.Any(e => e.DirectoryClientsID == id);
        }
    }
}
