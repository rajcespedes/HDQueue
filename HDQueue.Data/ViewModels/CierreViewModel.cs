using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDQueue.Data.ViewModels
{
    public class CierreViewModel
    {
        [Required]
        public int TicketID { get; set; }

        [Required]
        public string TecnicoId { get; set; }

       
        public string Titulo { get; set; }

        [Required]
        public string Comentario { get; set; }

    }
}
