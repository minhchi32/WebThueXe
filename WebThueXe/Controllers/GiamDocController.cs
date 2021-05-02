using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThueXe.Models;

namespace WebThueXe.Controllers
{
    public class GiamDocController : Controller
    {
        DBCarRentalEntities database = new DBCarRentalEntities();

        // GET: GiamDoc
        public ActionResult Index()
        {
            return View();
        }
        
    }
}