﻿using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModel
{
    public class AddEventviewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be 3 and 50 charecters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description is too long.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public string Date { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Location name is required.")]
        [Display(Name = "Events Location")]
        public string EventLocation { get; set; }

        [Required(ErrorMessage = "Number of attendee  is required.")]
        [Display(Name = "Number of Attendees")]
        [Range(0, 10, ErrorMessage = "Name must be 0 and 10 charecters.")]
        public int NumberOfAtendee { get; set; }


        [Compare(nameof(IsTrue), ErrorMessage = "Registration Required. Please Check the Box")]
        public bool Register { get; set; }


        public bool IsTrue { get { return true; } }

        //public EventType Type { get; set; } //enum // replace this with CategoryId

        [Required(ErrorMessage ="Category is required")]
        public int CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }  //this Line 46 replace line 48-60

       // public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>

       // // <option Value ='0'>Conference</option> 
       ////  < option Value ='0'>meetup</option>
       // {

       // new SelectListItem(EventType.Conference.ToString(), ((int) EventType.Conference).ToString()),
       // new SelectListItem(EventType.Meetup.ToString(), ((int)EventType.Meetup).ToString()),
       // new SelectListItem(EventType.Social.ToString(), ((int)EventType.Social).ToString()),
       // new SelectListItem(EventType.Workshop.ToString(), ((int)EventType.Workshop).ToString())


       // };

        public AddEventviewModel(List<EventCategory> categories)

        {
            Categories = new List<SelectListItem>();

            foreach(var category in categories)
            {
                Categories.Add(new SelectListItem { Value = category.Id.ToString(), Text= category.Name });

            };
        }

        public AddEventviewModel() { } // Empty Constructor
        
    }
}
