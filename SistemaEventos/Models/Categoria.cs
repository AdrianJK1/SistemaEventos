using System.ComponentModel.DataAnnotations;

namespace SistemaEventos.Models
{
    public class Categoria
    {
        [Key] 
        public int Id { get; set; }


        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Nombre ")]

        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripcion es requerido")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Categoria ")]

        public string DescripcionCategoria { get; set; } = string.Empty;


    }
}
