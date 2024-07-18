using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEventos.Models
{
    public class RegistroEvento
    {
        [Key] 
        public int Id { get; set; }

        [ForeignKey("Evento")]
        [Required(ErrorMessage = "El evento es requerido")]
        [Display(Name = "Evento")]
        public int EventoID { get; set; }

        [ForeignKey("Participante")]
        [Required(ErrorMessage = "El participante es requerido")]
        [Display(Name = "Participante")]
        public int ParticipanteID { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [Display(Name = "Fecha del Registro ")]
        public DateOnly FechaDelRegistro { get; set; }

        //Propiedad de navegacion
        public Evento? Evento { get; set; }
        public Participante? Participante { get; set; }


    }
}
