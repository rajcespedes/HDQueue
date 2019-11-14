using HDQueue;
using HDQueue.Data;
using HDQueue.Data.Entities;
using HelpDeskTicketHandler;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HelpDeskTicketHandler.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly ITicketService ticketService;
        private readonly ApplicationUserManager _userManager;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        // GET: Ticket
        public async Task<ActionResult> Index()
        {
            var lista = await ticketService.Listar();
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
            string userId = User.Identity.GetUserId();
            ticket.Fecha = DateTime.Today;
            ticket.UserId = userId;
            ticket.Estado = Estado.Pendiente;
            ticketService.CrearTicket(ticket);

            return RedirectToAction("Details", new { Id = ticket.Id });
        }

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{

        //    ticketService.GetById(id);

        //    return View();

        //}

        //[HttpPost]

        //public ActionResult Edit(Ticket ticket)
        //{

        //    ticketService.Modificar(ticket);

        //    return RedirectToAction("Details", new { id = ticket.Id });
        //}

        public ActionResult Details(int id)
        {

            var visualizarTicket = ticketService.GetTicket(id);

            return View(visualizarTicket);
        }
    }
}