using HDQueue.Data;
using HDQueue.Data.Entities;
using HDQueue.Data.ViewModels;
using HDQueue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HDQueue.Controllers
{
    public class TecnicoController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ITecnicoService tecnicoService;

        // GET: Tecnico

        public TecnicoController(ITicketService ticketService, ITecnicoService tecnicoService)
        {
            this._ticketService = ticketService;
            this.tecnicoService = tecnicoService;
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> NoAsignados()
        {
            var tickets = await _ticketService.Listar();

            tickets = tickets.Where(c => c.Estado == Estado.Pendiente);

            return View(tickets);
        }

        [HttpGet]
        public  ActionResult Asignar(int Id)
        {
            var ticket =  _ticketService.GetById(Id);


            if (ticket.Estado != Estado.Pendiente)
                return HttpNotFound();

            var tecnicos = tecnicoService.GetList();
            ViewBag["tecnicoList"] = new SelectList(tecnicos, "Id", "Nombre", ticket.TecnicoId);

            return View(ticket);
        }


        [HttpPost]
        public async Task<ActionResult> AsignarTicket(AsignacionViewModel asignacion) {

            await _ticketService.AsignarTicket(asignacion);

            TempData["Title"] = "Tickets no asignados";
            return RedirectToAction("Index", "Ticket");
            
        }
    }
}
