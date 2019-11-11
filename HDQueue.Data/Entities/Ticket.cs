using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDQueue.Data.Entities
{
    public class Ticket

    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Titulo es requerido")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Detalle es requerido")]
        public string Detalle { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        
        public DateTime Fecha = DateTime.Now;

        [Required(ErrorMessage = "Contacto es requerido")]
        public string Contacto { get; set; }

        public string Estado { get; set; }

        public string Tecnico { get; set; }
    }
}
