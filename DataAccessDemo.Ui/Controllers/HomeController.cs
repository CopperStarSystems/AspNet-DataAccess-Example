using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataAccessDemo.Ui.Models;

namespace DataAccessDemo.Ui.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult AdvancedSearch()
        {
            var model = new AdvancedSearchCriteria();
            return View(model);
        }

        [HttpPost]
        public ActionResult AdvancedSearch(AdvancedSearchCriteria searchCriteria)
        {
            var people = new List<Person>();
            using (var context = new DataAccessDemoEntities())
            {
                var tmp = context.People.AsQueryable();
                if (!string.IsNullOrEmpty(searchCriteria.FirstName))
                    tmp = tmp.Where(p => p.FirstName == searchCriteria.FirstName);
                if (!string.IsNullOrEmpty(searchCriteria.LastName))
                    tmp = tmp.Where(p => p.LastName == searchCriteria.LastName);
                people = tmp.ToList();
            }

            var result = new PeopleSearchData(people);
            return View("AdvancedSearchResults", result);
        }

        public ActionResult Index(string name = null)
        {
            var data = new List<Person>();

            using (var context = new DataAccessDemoEntities())
            {
                var people = context.People;
                if (name != null)
                    data = people.Where(p => p.FirstName == name).ToList();
                else
                    data = people.ToList();
            }

            var searchResults = new PeopleSearchData(data);

            return View(searchResults);
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            return RedirectToAction(nameof(Index), new {name = formCollection["firstName"]});
        }
    }
}