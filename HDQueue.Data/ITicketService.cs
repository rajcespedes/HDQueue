using HDQueue.Data.Entities;
using HDQueue.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDQueue.Data
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> Listar();
        void CrearTicket(Ticket ticket);
        Ticket GetById(int id);
        void Modificar(Ticket ticket);
        Ticket GetTicket(int id);

        Task AsignarTicket(AsignacionViewModel asignacion);
        Task Transferir(Transferir transferir);
    }
}