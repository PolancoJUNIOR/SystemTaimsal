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
    public class MachinesController : Controller
    {
        private readonly SysTaimsalBDContext _context = new SysTaimsalBDContext();

        // GET: Machines
        public async Task<IActionResult> Index()
        {
              return View(await _context.Machines.ToListAsync());
        }

        // GET: Machines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Machines == null)
            {
                return NotFound();
            }

            var machine = await _context.Machines
                .FirstOrDefaultAsync(m => m.IdMachine == id);
            if (machine == null)
            {
                return NotFound();
            }

            return View(machine);
        }

        // GET: Machines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Machines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMachine,NameMachine,ImageMachine")] Machine machine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(machine);
        }

        // GET: Machines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Machines == null)
            {
                return NotFound();
            }

            var machine = await _context.Machines.FindAsync(id);
            if (machine == null)
            {
                return NotFound();
            }
            return View(machine);
        }

        // POST: Machines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMachine,NameMachine,ImageMachine")] Machine machine)
        {
            if (id != machine.IdMachine)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineExists(machine.IdMachine))
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
            return View(machine);
        }

        // GET: Machines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Machines == null)
            {
                return NotFound();
            }

            var machine = await _context.Machines
                .FirstOrDefaultAsync(m => m.IdMachine == id);
            if (machine == null)
            {
                return NotFound();
            }

            return View(machine);
        }

        // POST: Machines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Machines == null)
            {
                return Problem("Entity set 'SysTaimsalBDContext.Machines'  is null.");
            }
            var machine = await _context.Machines.FindAsync(id);
            if (machine != null)
            {
                _context.Machines.Remove(machine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachineExists(int id)
        {
          return _context.Machines.Any(e => e.IdMachine == id);
        }
    }
}
