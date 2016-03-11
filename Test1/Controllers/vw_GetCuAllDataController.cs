using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test1.Models;

namespace Test1.Controllers
{
    public class vw_GetCuAllDataController : Controller
    {
        private CuEntities db = new CuEntities();

        // GET: vw_GetCuAllData
        public ActionResult Index()
        {
            return View(db.vw_GetCuAllData.ToList());
        }
        [HttpPost]
        public ActionResult SearchIndex(string keyword)
        {
            var data = db.vw_GetCuAllData.OrderByDescending(p => p.客戶名稱).AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(p => p.客戶名稱.Contains(keyword)).Take(5);
            }
            return View(data);
        }      


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
