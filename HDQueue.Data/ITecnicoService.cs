using HDQueue.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDQueue.Data
{
    public interface ITecnicoService
    {
        IEnumerable<ApplicationUser> GetList();
    }
}
