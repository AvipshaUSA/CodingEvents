using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CodingEvents.Models;  // used because Event data type is list below is in different folder. so we import.
using Microsoft.VisualBasic.CompilerServices;
using CodingEvents.Data; // used because we need to import EventData from Data/EventData.cs
using CodingEvents.ViewModel; // used because we need to import AddEventviewModel.cs from DataModel/AddEventviewModel.cs.cs

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {

        //static private List<Event> Events = new List<Event>();

        private EventDbContext context;
        public EventsController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        //GET: /<controller> /

        [HttpGet] // we want index only response to the get method on localhost 5001/events.
        public IActionResult Index()
        {
            /*      List<Event> events = new List<Event>(EventData.GetAll());*/ // we deleted EventData.cs from Data. 
            List<Event> events = context.Events.ToList();// created for EventDbcontext.cs 

            return View(events);
        }
        //  ViewBag.events = EventData.GetAll();
        //return View();

       

        
          

        [HttpGet]
        public IActionResult AddEvents() // this addEvents() action method going to responds to getRequest at the localhost 5001/addevents
        {
            List<EventCategory> categories = context.Categories.ToList();
            AddEventviewModel addEventViewModel = new AddEventviewModel(); // creating an instance of the class AddEventviewModel.cs
            return View(addEventViewModel);
        }

        [HttpPost]
        // [Route("/Events/AddEvents")] we added this httpPost rout inside Events.AddEvent <div> as asp-controller="Events" asp-controller = "AddEvents"
        //public IActionResult NeWevent(Event newEvent) // this argument names are comming from Events/Addevent.cshtml 's.
        //we declared the names of input as name and description
        //public IActionResult NeWevent(Event newEvent)
        // public IActionResult AddEvent(Event newEvent)// /Event/Add..same method name as httpGt. HttpGet Add retrieve the View form and httpPost responds to processing the view form
        public IActionResult AddEvents(AddEventviewModel addEventViewModel)
        {

            if (ModelState.IsValid)
            {

                EventCategory thecategory = context.Categories.Find(addEventViewModel.CategoryId);
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    Date = addEventViewModel.Date,
                    ContactEmail = addEventViewModel.ContactEmail,
                    EventLocation = addEventViewModel.EventLocation,
                    NumberOfAtendee = addEventViewModel.NumberOfAtendee,
                    Register = addEventViewModel.Register,
                    //Type = addEventViewModel.Type // this line removed 
                    Category = thecategory   // And we nolonger using Enum class EventType. so we are Deleting it. It is no more Models/EventType.cs

                };
                /*EventData.Add(newEvent); */// Add method from Data/Eventdata.cd has one argument. so here we pass new Event(name, description, date) as an argument.
                context.Events.Add(newEvent); //Add() method / keyword
                context.SaveChanges(); // savechanges() method/keyword . it saves what we add.

                return Redirect("/Events"); // redirect to action method

            }

            return View(addEventViewModel);
        }


        
        
        public IActionResult DeleteEvents()

        {

            /*  ViewBag.events = EventData.GetAll();*/ // we want to display the user what we have in list
            ViewBag.events = context.Events.ToList(); // gonna do same as GetAll() whisch was in Data/EventData.cs now deleted
           return View();
          
        }
        [HttpPost]
        public IActionResult DeleteEvents(int[] eventIds) // create method in the same name of above to post the delete.
        {
            foreach (var eventId in eventIds)
            {
                //EventData.Remove(eventId); //gonna do same as Removel() whisch was in Data/EventData.cs now deleted
                Event theEvent = context.Events.Find(eventId);
                context.Events.Remove(theEvent);
            }

            context.SaveChanges(); //gonna save everything 
            return Redirect("/Events");
        }

        // need to work on Edit

        [Route("/Events/Edit/{eventId}")] // this rout will take us to  the selected id no 
        public IActionResult Edit(int eventId)
        {

            /*ViewBag.eventsDictionaryObj = EventData.GetById(eventId);*/// picking the value which is a class type List, corresponding to the Id.
         

            ViewBag.eventsDictionaryObj = context.Events.Find(eventId);
            ViewBag.title = "You are editing " + ViewBag.eventsDictionaryObj.Name + " (id= #" + ViewBag.eventsDictionaryObj.Id + ")";
          
        

            // controller code will go here
            return View();
        }


        [HttpPost]
        [Route("/events/edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description, string date, string email, int numOfAttendee, string location)
        {

            /*Event updated = EventData.GetById(eventId);*/  // Event is class type list and a Value od Events dictionary. 
                                                             //so to get that Event List value which is acctualy a class type ,we need to create an object of Event Class.
            Event updated = context.Events.Find(eventId);

            //updating the fields
            updated.Name = name;
            updated.Description = description;
            updated.ContactEmail = email;
            updated.NumberOfAtendee = numOfAttendee;
            updated.EventLocation = location;
            updated.Date = date;
            // controller code will go here

            context.SaveChanges();
            return Redirect("/Events");
        }

    }
}
