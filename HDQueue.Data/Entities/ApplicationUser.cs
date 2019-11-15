using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HDQueue.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {

        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Cierre> Cierres { get; set; }
        public TipoDeUsuario TipoDeUsuario { get; set; }

        public string Nombre { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;


        }


    }

    public enum TipoDeUsuario
    {
        Admin =1,
        Tecnico,
        Cliente
    }
}
