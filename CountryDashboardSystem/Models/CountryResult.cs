using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryDashboardSystem.Models
{

    public class CountryResult
    {
        public Countries countries { get; set; }
    }

    public class Countries
    {
        public _Country[] country { get; set; }
    }

    public class _Country
    {
        public string iso2Code { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public string adminregion { get; set; }
        public string incomeLevel { get; set; }
        public string lendingType { get; set; }
        public string capitalCity { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }

}
