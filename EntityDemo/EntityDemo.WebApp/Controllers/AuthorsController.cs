using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityDemo.WebApp.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: Authors
        public ActionResult Index()
        {
            var context = new SciFiContext();

            
            var authors = context.Authors;

            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }

            return View(authors);
        }
    }
}