using HmwkAPI.Data.API;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;

namespace HmwkAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var manager = new ManagerRepository();
            var list = manager.GetTopTwenty();
            return View(manager.GetTheStuff(list));
        }

     
    }
}