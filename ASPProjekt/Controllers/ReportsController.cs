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
    [Authorize(Roles = "Admin,User,Dev")]
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ReportsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: Reports
        public async Task<IActionResult> Index()
        {
              return View(await dbContext.Report.ToListAsync());
        }

        // GET: Reports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || dbContext.Report == null)
            {
                return NotFound();
            }

            var report = await dbContext.Report
                .FirstOrDefaultAsync(m => m.IdRaport == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // GET: Reports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRaport,Topic,Environment,Description,status")] Report report)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(report);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }

        // GET: Reports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || dbContext.Report == null)
            {
                return NotFound();
            }

            var report = await dbContext.Report.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRaport,Topic,Environment,Description,status")] Report report)
        {
            if (id != report.IdRaport)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(report);
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportExists(report.IdRaport))
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
            return View(report);
        }

        // GET: Reports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || dbContext.Report == null)
            {
                return NotFound();
            }

            var report = await dbContext.Report
                .FirstOrDefaultAsync(m => m.IdRaport == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (dbContext.Report == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Report'  is null.");
            }
            var report = await dbContext.Report.FindAsync(id);
            if (report != null)
            {
                dbContext.Report.Remove(report);
            }
            
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportExists(int id)
        {
          return dbContext.Report.Any(e => e.IdRaport == id);
        }
    }
}
