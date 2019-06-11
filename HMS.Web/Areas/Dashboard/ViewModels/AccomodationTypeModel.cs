using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.Web.Areas.Dashboard.ViewModels
{
    public class AccomodationTypeModel
    {
        public IEnumerable<AccomodationType> AccomodationTypes { get; set; }
    }
}