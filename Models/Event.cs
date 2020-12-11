using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Models
{


    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string ContactEmail { get; set; }
        public string EventLocation { get; set; }
        public int NumberOfAtendee { get; set; }
        public bool Register { get; set; }
        public bool IsTrue { get { return true; } }
        //public EventType Type { get; set; } // enum type 

        public EventCategory Category { get; set; }
        public int CategoryId { get; set; }


        public int Id { get; set; }
      //  private static int nextId = 1;  no longer need this incrementation because mapper creating db and take care od the id through primary key


        public Event()
        {
            //Id = nextId; dbms gonna take care of this ids
            //nextId++;
        }

        public Event(string name, string description, string date, string contactEmail, string eventLocation, int numberOfAtendee, bool register, EventCategory category) : this()// constructor
        {
            Name = name;
            Description = description;
            Date = date;
            ContactEmail = contactEmail;
            EventLocation = eventLocation;
            NumberOfAtendee = numberOfAtendee;
            Register = register;
            Category = category;

        }

        public override string ToString()
        {
            return base.ToString();
        }


    }
}
