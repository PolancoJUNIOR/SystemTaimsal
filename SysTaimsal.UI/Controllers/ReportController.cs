using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SysTaimsal.DAL;
using SysTaimsal.EL;

namespace SysTaimsal.UI.Controllers
{
    public class ReportController : Controller
    {
        private readonly SysTaimsalBDContext _context = new SysTaimsalBDContext();

        // GET: Report
        public async Task<IActionResult> Index()
        {
            var sysTaimsalBDContext = _context.Reports.Include(r => r.Client).Include(r => r.Machine).Include(r => r.Product).Include(r => r.Provider).Include(r => r.user);
            return View(await sysTaimsalBDContext.ToListAsync());
        }

        // GET: Report/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reports == null)
            {
                return NotFound();
            }

            var report = await _context.Reports
                .Include(r => r.Client)
                .Include(r => r.Machine)
                .Include(r => r.Product)
                .Include(r => r.Provider)
                .Include(r => r.user)
                .FirstOrDefaultAsync(m => m.IdReport == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // GET: Report/Create
        public IActionResult Create()
        {
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "NameClient");
            ViewData["IdMachine"] = new SelectList(_context.Machines, "IdMachine", "NameMachine");
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "ImageProduct");
            ViewData["IdProvider"] = new SelectList(_context.Providers, "IdProvider", "NameProvider");
            ViewData["IdUser"] = new SelectList(_context.UserDevs, "IdUser", "LastNameUser");
            return View();
        }

        // POST: Report/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReport,IdClient,IdProduct,IdProvider,IdMachine,IdUser")] Report report)
        {
            if (ModelState.IsValid)
            {
                _context.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "NameClient", report.IdClient);
            ViewData["IdMachine"] = new SelectList(_context.Machines, "IdMachine", "NameMachine", report.IdMachine);
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "ImageProduct", report.IdProduct);
            ViewData["IdProvider"] = new SelectList(_context.Providers, "IdProvider", "NameProvider", report.IdProvider);
            ViewData["IdUser"] = new SelectList(_context.UserDevs, "IdUser", "LastNameUser", report.IdUser);
            return View(report);
        }

        // GET: Report/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reports == null)
            {
                return NotFound();
            }

            var report = await _context.Reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "NameClient", report.IdClient);
            ViewData["IdMachine"] = new SelectList(_context.Machines, "IdMachine", "NameMachine", report.IdMachine);
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "ImageProduct", report.IdProduct);
            ViewData["IdProvider"] = new SelectList(_context.Providers, "IdProvider", "NameProvider", report.IdProvider);
            ViewData["IdUser"] = new SelectList(_context.UserDevs, "IdUser", "LastNameUser", report.IdUser);
            return View(report);
        }

        // POST: Report/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReport,IdClient,IdProduct,IdProvider,IdMachine,IdUser")] Report report)
        {
            if (id != report.IdReport)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportExists(report.IdReport))
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
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "NameClient", report.IdClient);
            ViewData["IdMachine"] = new SelectList(_context.Machines, "IdMachine", "NameMachine", report.IdMachine);
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "ImageProduct", report.IdProduct);
            ViewData["IdProvider"] = new SelectList(_context.Providers, "IdProvider", "NameProvider", report.IdProvider);
            ViewData["IdUser"] = new SelectList(_context.UserDevs, "IdUser", "LastNameUser", report.IdUser);
            return View(report);
        }

        // GET: Report/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reports == null)
            {
                return NotFound();
            }

            var report = await _context.Reports
                .Include(r => r.Client)
                .Include(r => r.Machine)
                .Include(r => r.Product)
                .Include(r => r.Provider)
                .Include(r => r.user)
                .FirstOrDefaultAsync(m => m.IdReport == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // POST: Report/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reports == null)
            {
                return Problem("Entity set 'SysTaimsalBDContext.Reports'  is null.");
            }
            var report = await _context.Reports.FindAsync(id);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportExists(int id)
        {
          return _context.Reports.Any(e => e.IdReport == id);
        }
    }
}
