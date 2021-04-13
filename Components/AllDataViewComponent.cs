using FagElGamousExcavation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamousExcavation.Components
{
    public class AllDataViewComponent : ViewComponent
    {
        private INDIContext Context;
        public AllDataViewComponent(INDIContext ctx)
        {
            Context = ctx;
        }
        public IViewComponentResult Invoke()
        {
            return View(Context.AllData);
        }
    }
}
