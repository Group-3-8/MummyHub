using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamousExcavation.Models.ViewModel
{
    public class BioViewModel
    {
        public IEnumerable<BioSampleData> BioData { get; set; }
        //public AllDataSearchModel Filter { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string UrlInfo { get; set; }
    }
}
