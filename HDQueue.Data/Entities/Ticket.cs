using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDQueue.Data.Entities
{
    public class Ticket

    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage ="Titulo es requerido")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Detalle es requerido")]
        public string Detalle { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Contacto es requerido")]
        public string Contacto { get; set; }

        public Estado Estado { get; set; } = Estado.Pendiente;

        public string TecnicoId { get; set; }

        [ForeignKey("UserId")]
        public virtual  ApplicationUser User { get; set; }

        [ForeignKey("TecnicoId")]
        [DisplayName("Tecnico")]
        public virtual ApplicationUser TecnicoAsignado { get; set; }

        public string Comentario { get; set; }

        public virtual Cierre Cierre { get; set; }

    }
}
