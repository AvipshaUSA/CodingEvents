﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {

        static private Dictionary<string,string> Events = new Dictionary<string,string>();

        
        //GET: /<controller> /

        [HttpGet] // we want index only response to the get method on localhost 5001/events.
        public IActionResult Index()
        {

            //Events.Add("My Events");
            //Events.Add("Your Events"); // we do not need this lines any more.
            //Events.Add("His Events");

            ViewBag.events = Events;
            return View();
        }

        [HttpGet]
        public IActionResult AddEvents() // this addEvents() action method going to responds to getRequest at the localhost 5001/addevents
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/AddEvents")]
        public IActionResult NeWevent(string name,string description)
        {
            string html="";
            //ViewBag.name = name;
            // 
            if (name == "" || name == null) {
                html = "<h1>Field is empty</h1>";
                                                // return Redirect("/Events");
                //return Content(html, "text/html");//  Redirect("/Events");
              return Redirect("/Events");
            }
           
            else {
                Events.Add(name, description);
            }
            return Redirect("/Events"); // redirect to action method
        }
    }
}
