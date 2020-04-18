using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demeter_v2.Models;

namespace Demeter_v2.Controllers
{
    public class CropsController : Controller
    {
        private DemeterEntities db = new DemeterEntities();

        // GET: Crops
        public ActionResult Index()
        {
            return View(db.Crops.ToList());
        }

      
    }
}
