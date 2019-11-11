using HDQueue.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDQueue.Data
{
    public class ITicketServiceEF : ITicketService
    {
        private readonly TicketHandlerContext context;

        public ITicketServiceEF(TicketHandlerContext context)
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

        public IEnumerable<Ticket> Listar()
        {
            return context.Tickets.ToList();
        }

        public void Modificar(Ticket ticket)
        {
            var ticketAModificar = context.Tickets.Single(t => t.Id == ticket.Id);

            ticketAModificar.Titulo = ticket.Titulo;
            ticketAModificar.Usuario = ticket.Usuario;
            ticketAModificar.Detalle = ticket.Detalle;
            //ticketAModificar.Contacto = ticket.Contacto;

            context.SaveChanges();
        }


    }


}