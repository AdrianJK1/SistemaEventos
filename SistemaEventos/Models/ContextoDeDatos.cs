using Microsoft.EntityFrameworkCore;

namespace SistemaEventos.Models
{
    public class ContextoDeDatos : DbContext
    {

        public ContextoDeDatos(DbContextOptions opciones) : base(opciones) {
        }

       public DbSet<Evento> Eventos { get; set; }

        public DbSet<Participante> Participantes { get; set;}

        public DbSet<Categoria> Categorias { get; set; }
    }
}
