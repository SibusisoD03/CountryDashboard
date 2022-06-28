using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryDashboardSystem.Models
{
    public class TResult
    {
        public string  IsoCode { get; set; }
        public string CountryName { get; set; }
        public string Region { get; set; }
        public string AdminRegion { get; set; }
        public string IncomeLevel { get; set; }
        public string LendingType { get; set; }
        public string CapitalCity { get; set; }
        public object Longitude { get; set; }
        public object Latitude { get; set; }
    }
}
