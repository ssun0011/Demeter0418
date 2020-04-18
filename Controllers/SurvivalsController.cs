using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Demeter_v2.Models;
using ExcelDataReader;
using LinqToExcel;

namespace Demeter_v2.Controllers
{
    public class SurvivalsController : Controller
    {
        private DemeterEntities db = new DemeterEntities();

        // GET: Survivals
        public ActionResult Index()
        {
            return View(db.Survivals.ToList());
        }




    }
}
