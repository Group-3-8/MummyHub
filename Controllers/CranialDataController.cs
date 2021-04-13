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
    public class CranialDataController : Controller
    {
        private readonly INDIContext _context;

        public CranialDataController(INDIContext context)
        {
            _context = context;
        }

        // GET: CranialData
        public async Task<IActionResult> Index()
        {
            return View(await _context.CranialData.ToListAsync());
        }

        // GET: CranialData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cranialData = await _context.CranialData
                .FirstOrDefaultAsync(m => m.CranialDataPk == id);
            if (cranialData == null)
            {
                return NotFound();
            }

            return View(cranialData);
        }

        // GET: CranialData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CranialData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CranialDataPk,SampleNumber,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,BurialLocSummary,UniqId,LowPairNs,HighPairNs,BurialPositioningNorthSouthDirection,BurialLocationNs,LowPairEw,HighPairEw,BurialPositioningEastWestDirection,BurialLocationEw,BurialNumber,BurialDepth,BurialSubplot,ArtifactsDescription,ArtifactFound,GilesGender,BodyGender,GenderCode")] CranialData cranialData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cranialData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cranialData);
        }

        // GET: CranialData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cranialData = await _context.CranialData.FindAsync(id);
            if (cranialData == null)
            {
                return NotFound();
            }
            return View(cranialData);
        }

        // POST: CranialData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CranialDataPk,SampleNumber,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,BurialLocSummary,UniqId,LowPairNs,HighPairNs,BurialPositioningNorthSouthDirection,BurialLocationNs,LowPairEw,HighPairEw,BurialPositioningEastWestDirection,BurialLocationEw,BurialNumber,BurialDepth,BurialSubplot,ArtifactsDescription,ArtifactFound,GilesGender,BodyGender,GenderCode")] CranialData cranialData)
        {
            if (id != cranialData.CranialDataPk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cranialData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CranialDataExists(cranialData.CranialDataPk))
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
            return View(cranialData);
        }

        // GET: CranialData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cranialData = await _context.CranialData
                .FirstOrDefaultAsync(m => m.CranialDataPk == id);
            if (cranialData == null)
            {
                return NotFound();
            }

            return View(cranialData);
        }

        // POST: CranialData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cranialData = await _context.CranialData.FindAsync(id);
            _context.CranialData.Remove(cranialData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CranialDataExists(int id)
        {
            return _context.CranialData.Any(e => e.CranialDataPk == id);
        }
    }
}
