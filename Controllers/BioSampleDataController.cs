using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FagElGamousExcavation.Models;

namespace FagElGamousExcavation
{
    public class BioSampleDataController : Controller
    {
        private readonly INDIContext _context;

        public BioSampleDataController(INDIContext context)
        {
            _context = context;
        }

        // GET: BioSampleData
        public async Task<IActionResult> Index()
        {
            return View(await _context.BioSampleData.ToListAsync());
        }

        // GET: BioSampleData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioSampleData = await _context.BioSampleData
                .FirstOrDefaultAsync(m => m.BioSamplePk2 == id);
            if (bioSampleData == null)
            {
                return NotFound();
            }

            return View(bioSampleData);
        }

        // GET: BioSampleData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BioSampleData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BioSamplePk2,BioSamplePk,BurialId,BurialLocSummary,BagNum,LowPairNs,HighPairNs,BurialLocationNs,LowPairEw,HighPairEw,BurialLocationEw,BurialSubplot,Area,BurialNumber,Cluster,DateFound,YearFound,PreviouslySampled,BiologicalNotes,BiologicalInitials,Column21")] BioSampleData bioSampleData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bioSampleData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bioSampleData);
        }

        // GET: BioSampleData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioSampleData = await _context.BioSampleData.FindAsync(id);
            if (bioSampleData == null)
            {
                return NotFound();
            }
            return View(bioSampleData);
        }

        // POST: BioSampleData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BioSamplePk2,BioSamplePk,BurialId,BurialLocSummary,BagNum,LowPairNs,HighPairNs,BurialLocationNs,LowPairEw,HighPairEw,BurialLocationEw,BurialSubplot,Area,BurialNumber,Cluster,DateFound,YearFound,PreviouslySampled,BiologicalNotes,BiologicalInitials,Column21")] BioSampleData bioSampleData)
        {
            if (id != bioSampleData.BioSamplePk2)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bioSampleData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BioSampleDataExists(bioSampleData.BioSamplePk2))
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
            return View(bioSampleData);
        }

        // GET: BioSampleData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioSampleData = await _context.BioSampleData
                .FirstOrDefaultAsync(m => m.BioSamplePk2 == id);
            if (bioSampleData == null)
            {
                return NotFound();
            }

            return View(bioSampleData);
        }

        // POST: BioSampleData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bioSampleData = await _context.BioSampleData.FindAsync(id);
            _context.BioSampleData.Remove(bioSampleData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BioSampleDataExists(int id)
        {
            return _context.BioSampleData.Any(e => e.BioSamplePk2 == id);
        }
    }
}
