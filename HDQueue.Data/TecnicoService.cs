using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDQueue.Data.Entities;

namespace HDQueue.Data
{
    public class TecnicoService : ITecnicoService
    {

        private readonly ApplicationDbContext context;

        public TecnicoService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<ApplicationUser> GetList()
        {
            return context.Users.Where(c => c.TipoDeUsuario == TipoDeUsuario.Tecnico).ToList();
        }
    }
}
