using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Database.Impl;
using Tours.Models;

namespace Tours.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ToursController : ApiController
    {
        public Tour Get()
        {
            var allUrlKeyValues = ControllerContext.Request.GetQueryNameValuePairs().ToList();

            var userid = allUrlKeyValues.SingleOrDefault(v => v.Key == "userid").Value;
            var screen = allUrlKeyValues.SingleOrDefault(v => v.Key == "screen").Value;

            IEnumerable<Tour> tours;

            using (IDocumentSession session = Db.Store.OpenSession())
            {
                tours = session.Query<Tour>();

                if (!string.IsNullOrEmpty(screen))
                {
                    tours = tours.Where(t => t.Screen == screen);

                    if (!string.IsNullOrEmpty(userid))
                    {
                        tours = tours.Where(t => t.SeenBy == null || !t.SeenBy.Contains(userid)).ToList();

                        foreach (var tour in tours)
                        {
                            if (tour.SeenBy == null)
                            {
                                tour.SeenBy = new List<string>();
                            }

                            tour.SeenBy.Add(userid);
                            session.Store(tour);
                        }

                        session.SaveChanges();
                    }
                }
            }

            Tour all = new Tour(){Steps = new List<Step>()};

            foreach (var tour in tours)
            {
                if (tour.Steps != null)
                {
                    all.Steps.AddRange(tour.Steps);
                }
            }

            return all;
        }

        public Tour Get(string id)
        {
            using (IDocumentSession session = Db.Store.OpenSession())
            {
                return session.Load<Tour>("tours/" + id);
            }
        }

        public void Delete()
        {
            using (IDocumentSession session = Db.Store.OpenSession())
            {
                foreach (var tour in session.Query<Tour>())
                {
                    session.Delete(tour);
                }
                
                session.SaveChanges();
            }
        }
    }
}
