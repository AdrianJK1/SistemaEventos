using Microsoft.EntityFrameworkCore;
using SistemaEventos.Models;

namespace SistemaEventos.Models
{
    public class ContextoDeDatos : DbContext
    {

        public ContextoDeDatos(DbContextOptions opciones) : base(opciones) {
        }

       public DbSet<Evento> Eventos { get; set; }

        public DbSet<Participante> Participantes { get; set;}

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RegistroEvento> RegistroEventos { get; set; }
    }
}
