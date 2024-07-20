using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEventos.Models
{
    public class Evento
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Nombre del evento ")]

        public string NombreEvento { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripcion es requerida")]
        [MaxLength(400, ErrorMessage = "Maximo 400 caracteres")]
        [Display(Name = "Descripcion del evento ")]
        public string DescripcionDelEvento { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha es requerida")]
        [Display(Name = "Fecha del Evento ")]
        public DateOnly FechaDelEvento { get; set; }

        [Required(ErrorMessage = "La ubicacion es requerida")]
        [MaxLength(100, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Ubicacion del evento ")]
        public string Ubicacion { get; set; } = string.Empty;

        //propiedad de navegacion
        public List<RegistroEvento>? RegistroEventos { get; set; }
   

    }
}
