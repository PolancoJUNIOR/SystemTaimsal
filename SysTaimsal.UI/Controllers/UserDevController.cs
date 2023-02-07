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
    public class UserDevController : Controller
    {
        private readonly SysTaimsalBDContext _context = new SysTaimsalBDContext();

        // GET: UserDev
        public async Task<IActionResult> Index()
        {
            var sysTaimsalBDContext = _context.UserDevs.Include(u => u.Rol);
            return View(await sysTaimsalBDContext.ToListAsync());
        }

        // GET: UserDev/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserDevs == null)
            {
                return NotFound();
            }

            var userDev = await _context.UserDevs
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (userDev == null)
            {
                return NotFound();
            }

            return View(userDev);
        }

        // GET: UserDev/Create
        public IActionResult Create()
        {
            ViewData["IdRol"] = new SelectList(_context.Rol, "IdRol", "NameRol");
            return View();
        }

        // POST: UserDev/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,IdRol,NameUser,LastNameUser,Login,Password,Status_User,RegistrationUser")] UserDev userDev)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userDev);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.Rol, "IdRol", "NameRol", userDev.IdRol);
            return View(userDev);
        }

        // GET: UserDev/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserDevs == null)
            {
                return NotFound();
            }

            var userDev = await _context.UserDevs.FindAsync(id);
            if (userDev == null)
            {
                return NotFound();
            }
            ViewData["IdRol"] = new SelectList(_context.Rol, "IdRol", "NameRol", userDev.IdRol);
            return View(userDev);
        }

        // POST: UserDev/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,IdRol,NameUser,LastNameUser,Login,Password,Status_User,RegistrationUser")] UserDev userDev)
        {
            if (id != userDev.IdUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userDev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDevExists(userDev.IdUser))
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
            ViewData["IdRol"] = new SelectList(_context.Rol, "IdRol", "NameRol", userDev.IdRol);
            return View(userDev);
        }

        // GET: UserDev/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserDevs == null)
            {
                return NotFound();
            }

            var userDev = await _context.UserDevs
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (userDev == null)
            {
                return NotFound();
            }

            return View(userDev);
        }

        // POST: UserDev/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserDevs == null)
            {
                return Problem("Entity set 'SysTaimsalBDContext.UserDevs'  is null.");
            }
            var userDev = await _context.UserDevs.FindAsync(id);
            if (userDev != null)
            {
                _context.UserDevs.Remove(userDev);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDevExists(int id)
        {
          return _context.UserDevs.Any(e => e.IdUser == id);
        }
    }
}
