using Microsoft.AspNetCore.Mvc;
using MovieTime.Models;

namespace MovieTime.Controllers
{
    public class PersonController : Controller
    {
        public string Index()
        {
            return "Hello World";
        }

        public IActionResult Hello()
        {
            ViewBag.Message = "Hello World";
            return View();
        }

        public IActionResult Info()
        {
            Person person = new Person();
            person.Name = "John";
            person.Age = 51;
            person.Location = "United States";
            return View(person);
        }
    }
}
