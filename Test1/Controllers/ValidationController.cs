using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test1.Models;

namespace Test1.Controllers
{
    public class ValidationController : Controller
    {
        private CuEntities db = new CuEntities();
        public JsonResult doesMailExist(string Email)
        {
            bool ifEmailExist = db.客戶資料.Where(p => p.Email == Email).Count() > 0 ? true : false;
            return Json(!ifEmailExist, JsonRequestBehavior.AllowGet);
        }

    }
}