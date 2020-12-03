using CodingEvents.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Data
{
    public class EventDbContext : DbContext  //Dbcontext is a class which we extended
    {
        public DbSet<Event> Events { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) // extended constructor, also DbContextOptions is a object
        {
        }
        }
}
