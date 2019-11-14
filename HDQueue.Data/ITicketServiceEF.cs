using HDQueue.Data.Entities;
using HDQueue.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDQueue.Data
{
    public class ITicketServiceEF : ITicketService
    {
        private readonly ApplicationDbContext context;

        public ITicketServiceEF(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void CrearTicket(Ticket ticket)
        {
            context.Tickets.Add(ticket);
            context.SaveChanges();
        }

        public Ticket GetById(int id)
        {
            return context.Tickets.SingleOrDefault(t => t.Id == id);
        }

        public Ticket GetTicket(int id)
        {
            var lista = Listar();

            var ticketEncontrado = context.Tickets.SingleOrDefault(t => t.Id == id);

            return ticketEncontrado;
        }

        public async Task<IEnumerable<Ticket>> Listar()
        {
            return await context.Tickets.ToListAsync();
        }

        public void Modificar(Ticket ticket)
        {
            var ticketAModificar = context.Tickets.Single(t => t.Id == ticket.Id);

            ticketAModificar.Titulo = ticket.Titulo;
            ticketAModificar.Detalle = ticket.Detalle;
            //ticketAModificar.Contacto = ticket.Contacto;

            context.SaveChanges();
        }

        public async Task AsignarTicket(AsignacionViewModel asignacion)
        {
            var ticket = await context.Tickets.FindAsync(asignacion.TicketId);

            if(ticket != null)
            {
                ticket.TecnicoId = asignacion.TecnicoId;
                await context.SaveChangesAsync();
            }
        }
    }
}