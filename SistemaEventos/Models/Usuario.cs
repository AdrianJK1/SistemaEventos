using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEventos.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La clave es obligatoria")]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "La clave debe tener 6 o 10 caracteres ", MinimumLength = 6)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio")]
        public string Role { get; set; } = "Usuario"; 

        [NotMapped]
        public bool KeepLoggedIn { get; set; }
    }
}
