using EFCodeFirst_Entegrasyonu.Models;
using EFCodeFirst_Entegrasyonu.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace EFCodeFirst_Entegrasyonu.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult homePage()
        {
            DatabaseContext db= new DatabaseContext();
            List<Kisiler> kisiler= db.Kisiler.ToList(); //select * from Kisiler

            return View(kisiler);
        }

    }
}