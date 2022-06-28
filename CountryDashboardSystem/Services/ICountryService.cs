using CountryDashboardSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryDashboardSystem.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<TResult>> GetCountries();
    }
}
