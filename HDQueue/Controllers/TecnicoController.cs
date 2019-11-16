using HDQueue.Data;
using HDQueue.Data.Entities;
using HDQueue.Data.ViewModels;
using HDQueue.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HDQueue.Controllers
{
    [Authorize]
    public class TecnicoController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ITecnicoService tecnicoService;
        private ApplicationUserManager _userManager;

        // GET: Tecnico

        public TecnicoController(ITicketService ticketService, ITecnicoService tecnicoService)
        {
            this._ticketService = ticketService;
            this.tecnicoService = tecnicoService;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
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
        public async Task<ActionResult> Asignados()
        {
            var user = await UserManager.FindByNameAsync(User.Identity.Name);
            var tickets = await _ticketService.Listar();

            tickets = tickets.Where(c => c.Estado == Estado.Asignado && c.TecnicoId == user.Id);

            return View(tickets);
        }



        [HttpGet]
        public  ActionResult Asignar(int Id)
        {
            var ticket =  _ticketService.GetById(Id);


            if (ticket.Estado != Estado.Pendiente)
                return HttpNotFound();

            var tecnicos = tecnicoService.GetList();
            ViewBag.tecnicoList = new SelectList(tecnicos, "Id", "Nombre", ticket.TecnicoId);

            return View(ticket);
        }


        [HttpPost]
        public async Task<ActionResult> Asignar(AsignacionViewModel asignacion) {

            await _ticketService.AsignarTicket(asignacion);


            return RedirectToAction("NoAsignados");
            
        }

        [HttpPost]

        public async Task<ActionResult> Transferir(Transferir transferir)
        {

            await _ticketService.Transferir(transferir);


            return RedirectToAction("Asignados");

        }

        [HttpGet]
        public ActionResult Transferir(int Id)
        {
            var ticket = _ticketService.GetById(Id);


            if (ticket == null || ticket.Estado != Estado.Asignado) {

                return HttpNotFound();

            }
            

            var tecnicos = tecnicoService.GetList();
            ViewBag.tecnicoList = new SelectList(tecnicos, "Id", "Nombre", ticket.TecnicoId);

            return View(ticket);
        }

        public async Task<ActionResult> Cerrar(int id) {

            var ticket = _ticketService.GetById(id);
            var user = await UserManager.FindByNameAsync(User.Identity.Name);

            if ((ticket == null || ticket.Estado != Estado.Asignado) && user.Id != ticket.TecnicoId)
            {

                return HttpNotFound();

            }           
            

            return View(ticket);
        }

        [HttpPost]
        public async Task<ActionResult> Cerrar([Bind(Include = "TicketId,ComentarioCierre")] Cierre cierre) 
        {

            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);
            cierre.TecnicoId = user.Id;
            ModelState.Clear();

            if (TryValidateModel(cierre))
            {
                await _ticketService.Cierre(cierre);
                return RedirectToAction("Asignados", "Tecnico");
            }

            return View(cierre);

        }

        public async Task<ActionResult> Details(int id, string returnUrl)
        {

            var visualizarTicket = await _ticketService.GetTicketAsync(id);

            ViewBag.ReturnUrl = returnUrl;

            return View(visualizarTicket);
        }

    }


    
}
