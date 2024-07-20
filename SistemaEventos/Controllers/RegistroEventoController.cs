using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaEventos.Models;
using System.Drawing.Printing;
using System.Linq;
using X.PagedList;

namespace SistemaEventos.Controllers
{
    public class RegistroEventoController : Controller
    {
        private readonly ContextoDeDatos contexto;
        public RegistroEventoController(ContextoDeDatos contexto)
        {
            this.contexto = contexto;
        }
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10; //numero de paginas
            int pageNumber = (page ?? 1); //pagina actual

            var registros = await contexto.RegistroEventos
            .Include(r => r.Evento)
            .Include(r => r.Participante)
            .OrderByDescending(r => r.Id) // Ordena los registros por ID (opcional)
            .ToPagedListAsync(pageNumber, pageSize);

            return View(registros);
        }
        public async Task<IActionResult> Details(int id)
        {
            // Busca el registro específico por Id e incluye las entidades relacionadas.
            var registro = await contexto.RegistroEventos
        .Include(r => r.Evento)
        .Include(r => r.Participante)
        .FirstOrDefaultAsync(r => r.Id == id);

            // Verifica si se encontró el registro.
            if (registro == null)
            {
                return NotFound(); // Retorna una vista 404 si no se encuentra el registro.
            }

            return View(registro); // Pasa el registro a la vista.
        }

        
    }
}
