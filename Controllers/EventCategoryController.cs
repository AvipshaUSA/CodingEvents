using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    public class EventCategoryController : Controller
    {

        //Pass the DbContext category values as a list into the view template as a model.
        private EventDbContext context;
        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        [Route("EventCategory/Index")]
        public IActionResult Index()
        {
      
            List<EventCategory> categories = context.Categories.ToList();
            return View(categories);
        }



        [HttpGet]

        public IActionResult Create()
        {

            AddEventCategoryViewModel addEventCategoryViewModel = new AddEventCategoryViewModel(); // creating an instance of the class AddEventCategoryViewModel.cs of viewModel
            return View(addEventCategoryViewModel);

        }




    
        [HttpPost("EventCategory/Create")]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel addEventCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory newEventCategory = new EventCategory
                {
                    Name = addEventCategoryViewModel.Name
                };

                context.Categories.Add(newEventCategory);
                context.SaveChanges();

                return Redirect("Index");
            }
            return View(addEventCategoryViewModel);
        }



        [HttpGet]
        public IActionResult DeleteCategory()

        {

            /*  ViewBag.events = EventData.GetAll();*/ // we want to display the user what we have in list
            ViewBag.categories = context.Categories.ToList(); // gonna do same as GetAll() whisch was in Data/EventData.cs now deleted
            return View();

        }



        [HttpPost]
        public IActionResult DeleteCategory(int[] eventIds) // create method in the same name of above to post the delete.
        {
            foreach (var eventId in eventIds)
            {
                //EventData.Remove(eventId); //gonna do same as Removel() whisch was in Data/EventData.cs now deleted
                EventCategory theEvent = context.Categories.Find(eventId);
                context.Categories.Remove(theEvent);
            }

            context.SaveChanges(); //gonna save everything 
            return Redirect("Index");
        }
    }
}
