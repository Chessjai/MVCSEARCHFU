using MVCSEARCHFUNC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSEARCHFUNC.Controllers
{
    public class CascadingDropdownController : Controller
    {
        // GET: CascadingDropdown
      
            private DDLCONTEXT _context = new DDLCONTEXT();
      

            public ActionResult Index()
            {
                var countries = _context.Country.ToList();
                ViewBag.Countries = new SelectList(countries, "Id", "Name");
                return View();
            }

            public JsonResult GetStatesByCountry(int countryId)
            {
                var states = _context.State.Where(s => s.CountryId == countryId).ToList();
                return Json(states, JsonRequestBehavior.AllowGet);
            }

            public JsonResult GetCitiesByState(int stateId)
            {
                var cities = _context.City.Where(c => c.StateId == stateId).ToList();
                return Json(cities, JsonRequestBehavior.AllowGet);
            }
        }


    }
