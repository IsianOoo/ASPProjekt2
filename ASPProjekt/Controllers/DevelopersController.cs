using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPProjekt.Data;
using ASPProjekt.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASPProjekt.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DevelopersController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public DevelopersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: Developers
        public async Task<IActionResult> Index()
        {
              return View(await dbContext.Developers.ToListAsync());
        }

        // GET: Developers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || dbContext.Developers == null)
            {
                return NotFound();
            }

            var developers = await dbContext.Developers
                .FirstOrDefaultAsync(m => m.IdDevelopers == id);
            if (developers == null)
            {
                return NotFound();
            }

            return View(developers);
        }

        // GET: Developers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Developers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDevelopers,Name,Surname")] Developers developers)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(developers);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(developers);
        }

        // GET: Developers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || dbContext.Developers == null)
            {
                return NotFound();
            }

            var developers = await dbContext.Developers.FindAsync(id);
            if (developers == null)
            {
                return NotFound();
            }
            return View(developers);
        }

        // POST: Developers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDevelopers,Name,Surname")] Developers developers)
        {
            if (id != developers.IdDevelopers)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(developers);
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevelopersExists(developers.IdDevelopers))
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
            return View(developers);
        }

        // GET: Developers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || dbContext.Developers == null)
            {
                return NotFound();
            }

            var developers = await dbContext.Developers
                .FirstOrDefaultAsync(m => m.IdDevelopers == id);
            if (developers == null)
            {
                return NotFound();
            }

            return View(developers);
        }

        // POST: Developers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (dbContext.Developers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Developers'  is null.");
            }
            var developers = await dbContext.Developers.FindAsync(id);
            if (developers != null)
            {
                dbContext.Developers.Remove(developers);
            }
            
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevelopersExists(int id)
        {
          return dbContext.Developers.Any(e => e.IdDevelopers == id);
        }
    }
}
