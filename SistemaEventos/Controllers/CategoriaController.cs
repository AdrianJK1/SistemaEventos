using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEventos.Models;
using X.PagedList;

namespace SistemaEventos.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ContextoDeDatos contextoDatos;

        //esta es la inyeccion de contexo de datos
        public CategoriaController(ContextoDeDatos contextoDatos)
        {
            this.contextoDatos = contextoDatos;
        }
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10; 
            int pageNumber = (page ?? 1); 

            var categorias = await contextoDatos.Categorias.OrderByDescending(c => c.Id).ToPagedListAsync(pageNumber, pageSize);
            
            return View(categorias);
        }
    }
}
