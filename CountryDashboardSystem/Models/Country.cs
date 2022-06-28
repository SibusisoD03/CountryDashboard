using System;
using System.Collections.Generic;

#nullable disable

namespace CountryDashboardSystem.Models
{
    public partial class Country
    {
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
        public string IsoCode { get; set; }
    }
}
