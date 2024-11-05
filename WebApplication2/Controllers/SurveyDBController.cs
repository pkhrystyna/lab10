using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entities;

namespace WebApplication2.Controllers
{
    public class Lab2Controller : Controller
    {
        public ActionResult ListOfPeople()
        {
            List<Person> people = new List<Person>();
            using (var db = new SurveyDB1Entities())
            {
                people = db.People.OrderByDescending(x => x.Age)
                    .ThenBy(x => x.LastName)
                    .ThenBy(x => x.FirstName).ToList();
            }
            return View(people);
        }
        [HttpGet]
        public ActionResult PersonDetails(Guid personId)
        {
            Person model = new Person();
            using (var db = new SurveyDB1Entities())
            {
                model = db.People.Find(personId);
            }
            return View(model);
        }

    }
}
