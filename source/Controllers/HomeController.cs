using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing.Constraints;
using System.Web.Mvc;
using Raven.Client;
using Tours.Models;

namespace Tours.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Tour());
        }

        [HttpPost]
        public ActionResult Index(Tour tour)
        {
            if (!ModelState.IsValid)
            {
                return View(tour);
            }

            using (IDocumentSession session = Db.Store.OpenSession())
            {
                session.Store(tour, tour.Id);

                if (tour.AddedStep != null && !string.IsNullOrEmpty(tour.AddedStep.Intro))
                {
                    if (tour.Steps == null)
                    {
                        tour.Steps = new List<Step>();
                    }

                    tour.Steps.Add(tour.AddedStep);

                    session.Store(tour, tour.Id);
                }

                session.SaveChanges();
            }


            return View(tour);
        }
    }
}
