using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamousExcavation.Models.ViewModel
{
    public class AllDataViewModel
    {
        public IEnumerable<AllData> AllData { get; set; }
        public AllDataSearchModel Filter{ get; set; }
        public string UrlInfo { get; set; }

    }
}
