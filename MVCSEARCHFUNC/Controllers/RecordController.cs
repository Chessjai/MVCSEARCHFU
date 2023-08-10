using MVCSEARCHFUNC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSEARCHFUNC.Controllers
{
  
        public class RecordController : Controller
        {
  
        private APPDBCONTEXT db = new APPDBCONTEXT();



        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult EditRecord(Record record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(record).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, message = "Record updated successfully." });
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new { success = false, message = "Record update failed.", errors = errors });
            }
        }

        [HttpPost]
        public ActionResult DeleteRecord(int id)
        {
            var record = db.Record.Find(id);
            if (record != null)
            {
                db.Record.Remove(record);
                db.SaveChanges();
                return Json(new { success = true, message = "Record deleted successfully." });
            }
            else
            {
                return Json(new { success = false, message = "Record not found." });
            }
        }
        [HttpPost]
        public ActionResult AjaxMethod(string searchValue, DateTime? startDate, DateTime? endDate, string country, string searchField, int? startId, int? endId)
        {
            IQueryable<Record> query = db.Record;

            if (!string.IsNullOrEmpty(searchValue))
            {
                if (searchField == "Id")
                {
                    query = query.Where(r => r.Id.ToString().Contains(searchValue));
                }
                else if (searchField == "Name")
                {
                    query = query.Where(r => r.Name.Contains(searchValue));
                }
                else if (searchField == "Country")
                {
                    query = query.Where(r => r.Country.Contains(searchValue));
                }
            }

            if (startId.HasValue && endId.HasValue)
            {
                query = query.Where(r => r.Id >= startId.Value && r.Id <= endId.Value);
            }

            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(r => r.StartDate >= startDate && r.EndDate <= endDate);
            }

            var records = query.ToList();
            return Json(records);
        }

        [HttpPost]
        public ActionResult InsertRecord(Record record)
        {
            if (ModelState.IsValid)
            {
                db.Record.Add(record);
                db.SaveChanges();
                return Json(new { success = true, message = "Record inserted successfully." });
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new { success = false, message = "Record insertion failed.", errors = errors });
            }
        }




    }


}
