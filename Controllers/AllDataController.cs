using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FagElGamousExcavation.Models;
using FagElGamousExcavation.Components;
using FagElGamousExcavation.Models.ViewModel;
using FagElGamousExcavation.Models.Filter;

namespace FagElGamousExcavation
{
    public class AllDataController : Controller
    {
        private INDIContext _context { get; set; }

        public AllDataController(INDIContext context)
        {
            _context = context;
        }

        // GET: AllData
        /*        [HttpGet]
                public async Task<IActionResult> Index()
                {
                    return View(New AllDataViewModel await _context.AllData.Take(5).ToListAsync());
                }*/
        [HttpGet]
        public IActionResult Index(AllDataSearchModel filter, int? burialId, int pageNum = 1)
        {
            var filterLogic = new FilterLogic(_context);

            var queryModel = filterLogic.GetMummies(filter);

            return View(new AllDataViewModel
            {

                AllData = (queryModel
                .Take(5)
                .ToList())
            });
        }

/*        [HttpPost]
        public IActionResult Index(AllDataSearchModel searchModel)
        {
            return View(_context.AllData
                .Where(x => x.BurialDirection.Contains(searchModel.BurialDirection) || searchModel.BurialDirection == null)
                .Where(x => x.YearFound.Contains(searchModel.YearFound) || searchModel.YearFound == null)
                .Where(x => x.HairColor.Contains(searchModel.HairColor) || searchModel.HairColor == null)
                .Where(x => x.BurialId.Contains(searchModel.BurialLocation) || searchModel.BurialLocation == null)
                .Where(x => x.EstimateAgeSingle.Contains(searchModel.AgeGroup) || searchModel.AgeGroup == null)
                .Where(x => x.GenderCode.Contains(searchModel.Gender) || searchModel.Gender == null)
                );
        }*/
        // GET: AllData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allData = await _context.AllData
                .FirstOrDefaultAsync(m => m.UniqId2 == id);
            if (allData == null)
            {
                return NotFound();
            }

            return View(allData);
        }

        // GET: AllData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AllData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniqId2,UniqId,BurialId,BurialLocSummary,BurialLocationNs,BurialLocationEw,LowPairNs,HighPairNs,LowPairEw,HighPairEw,BurialSubplot,AreaHillBurials,TombBurial,BurialDepth,SouthToHead,SouthToFeet,WestToHead,WestToFeet,BurialSituation,LengthOfBurialCm,BurialNumber,SampleNumber,GenderCode,BurialGenderMethod,GenderGe,GeFunctionTotal,GenderBodyCol,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForemanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,ArtifactsDescription,Goods,HairColor,HairColorCode,PreservationIndex,BurialPreservation,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,BurialSampleTaken,PreviouslySampled,DescriptionOfTaken,ArtifactFound,EstimateAgeGroup,EstimateAgeSingle,BurialAgeMethod,EstimateAge,EstimateLivingStature,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,YearFound,MonthFound,DayFound,HeadDirection,BurialDirection,FaceBundle,Questions,Calibrated95CalendarDateAvg,Category,BiologicalNotes,BiologicalInitials,OsteologyNotes,Notes,BagNum,Cluster,FieldBook1,FieldBook2,FieldBook3,FieldBook32,FieldBook4,FieldBook5,FieldBook6,FieldBook7,FieldBook8,UnknownColSorted,YearOnSkull,MonthOnSkull,DateOnSkull,FieldBook,FieldBookPageNumber,InitialsOfDataEntryExpert,InitialsOfDataEntryChecker,ByuSample,BodyAnalysis,SkullAtMagazine,PostcraniaAtMagazine,SexSkull2018,AgeSkull2018,RackAndShelf,ToBeConfirmed,SkullTrauma,PostcraniaTrauma,CribraOrbitala,PoroticHyperostosis,PoroticHyperostosisLocations,MetopicSuture,ButtonOsteoma,PostcraniaTrauma2,OsteologyUnknownComment,TemporalMandibularJointOsteoarthritisTmjOa,LinearHypoplasiaEnamel")] AllData allData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allData);
        }

        // GET: AllData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allData = await _context.AllData.FindAsync(id);
            if (allData == null)
            {
                return NotFound();
            }
            return View(allData);
        }

        // POST: AllData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniqId2,UniqId,BurialId,BurialLocSummary,BurialLocationNs,BurialLocationEw,LowPairNs,HighPairNs,LowPairEw,HighPairEw,BurialSubplot,AreaHillBurials,TombBurial,BurialDepth,SouthToHead,SouthToFeet,WestToHead,WestToFeet,BurialSituation,LengthOfBurialCm,BurialNumber,SampleNumber,GenderCode,BurialGenderMethod,GenderGe,GeFunctionTotal,GenderBodyCol,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForemanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,ArtifactsDescription,Goods,HairColor,HairColorCode,PreservationIndex,BurialPreservation,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,BurialSampleTaken,PreviouslySampled,DescriptionOfTaken,ArtifactFound,EstimateAgeGroup,EstimateAgeSingle,BurialAgeMethod,EstimateAge,EstimateLivingStature,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,YearFound,MonthFound,DayFound,HeadDirection,BurialDirection,FaceBundle,Questions,Calibrated95CalendarDateAvg,Category,BiologicalNotes,BiologicalInitials,OsteologyNotes,Notes,BagNum,Cluster,FieldBook1,FieldBook2,FieldBook3,FieldBook32,FieldBook4,FieldBook5,FieldBook6,FieldBook7,FieldBook8,UnknownColSorted,YearOnSkull,MonthOnSkull,DateOnSkull,FieldBook,FieldBookPageNumber,InitialsOfDataEntryExpert,InitialsOfDataEntryChecker,ByuSample,BodyAnalysis,SkullAtMagazine,PostcraniaAtMagazine,SexSkull2018,AgeSkull2018,RackAndShelf,ToBeConfirmed,SkullTrauma,PostcraniaTrauma,CribraOrbitala,PoroticHyperostosis,PoroticHyperostosisLocations,MetopicSuture,ButtonOsteoma,PostcraniaTrauma2,OsteologyUnknownComment,TemporalMandibularJointOsteoarthritisTmjOa,LinearHypoplasiaEnamel")] AllData allData)
        {
            if (id != allData.UniqId2)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllDataExists(allData.UniqId2))
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
            return View(allData);
        }

        // GET: AllData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allData = await _context.AllData
                .FirstOrDefaultAsync(m => m.UniqId2 == id);
            if (allData == null)
            {
                return NotFound();
            }

            return View(allData);
        }

        // POST: AllData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allData = await _context.AllData.FindAsync(id);
            _context.AllData.Remove(allData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllDataExists(int id)
        {
            return _context.AllData.Any(e => e.UniqId2 == id);
        }
    }
}
