using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLEOC.Models;

namespace SLEOC.Controllers
{
    public class StartController : Controller
    {
        public ActionResult Interface(InterfaceModel model)
        {
            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
