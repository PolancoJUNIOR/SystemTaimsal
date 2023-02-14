using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SysTaimsal.DAL;
using SysTaimsal.EL;
using SysTaimsal.UI.Models;

namespace SysTaimsal.UI.Controllers
{
    public class MachineController : Controller
    {
        private readonly SysTaimsalBDContext _context = new SysTaimsalBDContext();
        private string SaveFile(IFormFile archivo)
        {
            FileViewModel fileViewModel = new FileViewModel();
            fileViewModel.name = Guid.NewGuid().ToString() + archivo.FileName;
            fileViewModel.path = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\GuardarImagen" + fileViewModel.name);
            using var stream = new FileStream(fileViewModel.path, FileMode.Create);
            archivo.CopyTo(stream);
            return "..\\GuardarImagen\\" + fileViewModel.name;
        }
        // GET: Machine
        public async Task<IActionResult> Index()
        {
            return View(await _context.Machines.ToListAsync());
        }

        // GET: Machine/Details/5
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

        // GET: Machine/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Machine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMachine,NameMachine,ImageMachine")] Machine machine, IFormFile FileUpload)
        {
            try
            {
                machine.ImageMachine = FileViewModel.SaveFile(FileUpload);
                if (ModelState.IsValid)
                {
                    _context.Add(machine);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(machine);
            }
            catch
            {
                return View(machine);
            }
        }

        // GET: Machine/Edit/5
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

        // POST: Machine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMachine,NameMachine,ImageMachine")] Machine machine, IFormFile FileUpload)
        {
            if (id != machine.IdMachine)
            {
                return NotFound();
            }

            machine.ImageMachine = FileViewModel.SaveFile(FileUpload);
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

        // GET: Machine/Delete/5
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

        // POST: Machine/Delete/5
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
