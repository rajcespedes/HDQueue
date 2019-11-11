using HDQueue.Data;
using HDQueue.Data.Entities;
using HelpDeskTicketHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDeskTicketHandler.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }
        // GET: Ticket
        public ActionResult Index()
        {
            var lista = ticketService.Listar();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Create(Ticket ticket)
        {

            ticketService.CrearTicket(ticket);

            return RedirectToAction("Details", new { Id = ticket.Id });

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            ticketService.GetById(id);

            return View();

        }

        [HttpPost]

        public ActionResult Edit(Ticket ticket)
        {

            ticketService.Modificar(ticket);

            return RedirectToAction("Details", new { id = ticket.Id });
        }

        public ActionResult Details(int id)
        {

            var visualizarTicket = ticketService.GetTicket(id);

            return View(visualizarTicket);
        }

    }
}