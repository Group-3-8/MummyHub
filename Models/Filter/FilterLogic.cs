using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamousExcavation.Models.Filter
{
    public class FilterLogic
    {
        private INDIContext _context { get; set; }





        public FilterLogic(INDIContext context)
        {
            _context = context;
        }





        public IQueryable<AllData> GetMummies(AllDataSearchModel searchModel, int pageNum = 1, int pageSize = 10)
        {



            var result = _context.AllData.AsQueryable();
            if (searchModel != null)
            {
                if (!string.IsNullOrEmpty(searchModel.BurialLocation))
                {
                    result = result.Where(x => x.BurialId.Contains(searchModel.BurialLocation));
                }
                if (!string.IsNullOrEmpty(searchModel.BurialDirection))
                {
                    result = result.Where(x => x.BurialDirection.Contains(searchModel.BurialDirection));
                }
                if (!string.IsNullOrEmpty(searchModel.HairColor))
                {
                    result = result.Where(x => x.HairColorCode.Contains(searchModel.HairColor));
                }
                if (!string.IsNullOrEmpty(searchModel.YearFound))
                {
                    result = result.Where(x => x.YearFound.Contains(searchModel.YearFound));
                }
                if (!string.IsNullOrEmpty(searchModel.Gender))
                {
                    result = result.Where(x => x.GenderCode.Contains(searchModel.Gender));
                }
                if (!string.IsNullOrEmpty(searchModel.AgeGroup))
                {
                    result = result.Where(x => x.EstimateAgeSingle.Contains(searchModel.AgeGroup));
                }

            }

            return result;
        }
    }
}
