using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CountryDashboardSystem.Models;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CountryDashboardSystem.Services;
using System.Text.Json;
using System.Xml;

namespace CountryDashboardSystem.Controllers
{
    public class CountryController : Controller
    {
        private readonly CountryDashboardContext _context;
        //private readonly ICountryService _countryService;   

        public CountryController(CountryDashboardContext context)
        {
            _context = context;  
        }

        // GET: Country
        public async Task<IActionResult> Index()
        {
            return View(await _context.Countries.Take(10).ToListAsync());            
        }
        //string Baseurl = "http://api.worldbank.org/v2/country";
        //public async Task<ActionResult> Index()
        //{
        //    List<TResult> EmpInfo = new List<TResult>();
        //    using (var client = new HttpClient())
        //    {
        //        //Passing service base url
        //        client.BaseAddress = new Uri(Baseurl);
        //        client.DefaultRequestHeaders.Clear();
        //        //Define request data format
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        //Sending request to find web api REST service resource GetAllEmployees using HttpClient
        //        HttpResponseMessage Res = await client.GetAsync("http://api.worldbank.org/v2/country");               

        //        //Checking the response is successful or not which is sent using HttpClient
        //        if (Res.IsSuccessStatusCode)
        //        {
        //            //Storing the response details recieved from web api
        //           // var EmpResponse = Res.Content.ReadAsStringAsync().Result;
        //            //Deserializing the response recieved from web api and storing into the Employee list
        //            //EmpInfo = JsonConvert.DeserializeObject<List<TResult>>(EmpResponse);

        //            using (var reponseStream = await Res.Content.ReadAsStreamAsync())
        //            {                        
        //                var options = new JsonSerializerOptions
        //                {
        //                    PropertyNameCaseInsensitive = true,
        //                };
        //                EmpInfo = await System.Text.Json.JsonSerializer.DeserializeAsync<List<TResult>>(reponseStream, options);
        //            }
        //        }
        //        //returning the employee list to view
        //        return View(EmpInfo);
        //    }
        //}


        // GET: Country/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                .FirstOrDefaultAsync(m => m.CountryId == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: Country/Create
        public IActionResult Create()
        {
            return View();
        }

        
        // POST: Country/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryId,CountryName,IsoCode")] Country country)
        {
            if (ModelState.IsValid)
            {
                if (CountryExists(country.IsoCode))
                {
                    
                }
                else
                {
                    country.CountryId = Guid.NewGuid();
                    _context.Add(country);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }                
            }
            return View(country);
        }

        // GET: Country/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: Country/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CountryId,CountryName,IsoCode")] Country country)
        {
            if (id != country.CountryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.CountryId))
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
            return View(country);
        }

        // GET: Country/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                .FirstOrDefaultAsync(m => m.CountryId == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var country = await _context.Countries.FindAsync(id);
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(string isoCode)
        {
            return _context.Countries.Any(e => e.IsoCode == isoCode);
        }

        private bool CountryExists(Guid id)
        {
            return _context.Countries.Any(e => e.CountryId == id);
        }

    }
}
