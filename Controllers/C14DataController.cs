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
    public class C14DataController : Controller
    {
        private readonly INDIContext _context;

        public C14DataController(INDIContext context)
        {
            _context = context;
        }

        // GET: C14Data
        public async Task<IActionResult> Index()
        {
            return View(await _context.C14Data.ToListAsync());
        }

        // GET: C14Data/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c14Data = await _context.C14Data
                .FirstOrDefaultAsync(m => m.C14Pk2 == id);
            if (c14Data == null)
            {
                return NotFound();
            }

            return View(c14Data);
        }

        // GET: C14Data/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: C14Data/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("C14Pk2,C14Pk,BurialLocSummary,BurialId,UniqId,Rack,LowPairNs,HighPairNs,BurialLocationNs,LowPairEw,HighPairEw,BurialLocationEw,BurialSubplot,Area,BurialNumber,Rack2,TubeNumber,Description,Size,Foci,C14Sample2017,Location,Questions,Conventional14cAgeBp,Column25,_14cCalendarDate,Calibrated95CalendarDateMax,Calibrated95CalendarDateMin,Calibrated95CalendarDateSpan,Calibrated95CalendarDateAvg,Category,Notes,Column33")] C14Data c14Data)
        {
            if (ModelState.IsValid)
            {
                _context.Add(c14Data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(c14Data);
        }

        // GET: C14Data/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c14Data = await _context.C14Data.FindAsync(id);
            if (c14Data == null)
            {
                return NotFound();
            }
            return View(c14Data);
        }

        // POST: C14Data/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("C14Pk2,C14Pk,BurialLocSummary,BurialId,UniqId,Rack,LowPairNs,HighPairNs,BurialLocationNs,LowPairEw,HighPairEw,BurialLocationEw,BurialSubplot,Area,BurialNumber,Rack2,TubeNumber,Description,Size,Foci,C14Sample2017,Location,Questions,Conventional14cAgeBp,Column25,_14cCalendarDate,Calibrated95CalendarDateMax,Calibrated95CalendarDateMin,Calibrated95CalendarDateSpan,Calibrated95CalendarDateAvg,Category,Notes,Column33")] C14Data c14Data)
        {
            if (id != c14Data.C14Pk2)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(c14Data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!C14DataExists(c14Data.C14Pk2))
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
            return View(c14Data);
        }

        // GET: C14Data/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c14Data = await _context.C14Data
                .FirstOrDefaultAsync(m => m.C14Pk2 == id);
            if (c14Data == null)
            {
                return NotFound();
            }

            return View(c14Data);
        }

        // POST: C14Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var c14Data = await _context.C14Data.FindAsync(id);
            _context.C14Data.Remove(c14Data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool C14DataExists(int id)
        {
            return _context.C14Data.Any(e => e.C14Pk2 == id);
        }
    }
}
