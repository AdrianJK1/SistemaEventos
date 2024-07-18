using System.ComponentModel.DataAnnotations;

namespace SistemaEventos.Models
{
    public class Participante
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Nombre ")]

        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Apellido ")]

        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es requerido")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Correo Electronico ")]

        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El numero es requerido")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Telefono ")]

        public string Telefono { get; set; } = string.Empty;

        //propiedad de navegacion
        public List<RegistroEvento>? RegistroEventos { get; set; }
    }
}
