using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDQueue.Data.Entities
{
    public class Cierre
    {

        [Required]
        public string TecnicoId { get; set; }

        [Required]
        [ForeignKey("Ticket"), Key]
        public int TicketID { get; set; }

        [Display(Name = "Comentario" )]
        [Required]
        public string ComentarioCierre { get; set; }

        [ForeignKey("TecnicoId")]
        public virtual ApplicationUser Tecnico { get; set; }

        public virtual Ticket Ticket { get; set; }

    }
}
