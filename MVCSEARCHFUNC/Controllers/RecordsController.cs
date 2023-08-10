using MVCSEARCHFUNC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSEARCHFUNC.Controllers
{
    public class RecordsController : Controller
    {


        private APPDBCONTEXT db = new APPDBCONTEXT(); // Use your own DbContext

        public ActionResult Index()
            {
            var people = db.Record.ToList();
            return View(people);
        }
            public ActionResult Search(string searchTerm)
            {
                var searchResults = db.Record
                    .Where(e => e.Name.Contains(searchTerm)) // Your search criteria
                    .ToList();

                return PartialView("_SearchResultsPartial", searchResults);
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
        public ActionResult LoadData(string searchTerm)
        {
            var query = db.Record.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.Name.Contains(searchTerm));
            }

            var people = query.ToList();

            return Json(new { data = people }, JsonRequestBehavior.AllowGet);
        }
    }
    }



    
