using HDQueue.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDQueue.Data
{
    public class TicketHandlerContext : DbContext
    {
        public TicketHandlerContext() : base("TicketHandlerDB")
        {

        }

        public DbSet<Ticket> Tickets { get; set; }

    }
}