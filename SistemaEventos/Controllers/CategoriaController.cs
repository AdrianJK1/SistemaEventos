using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEventos.Models;
using X.PagedList;

namespace SistemaEventos.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ContextoDeDatos contexto;
        public CategoriaController(ContextoDeDatos contexto)
        {
            this.contexto = contexto;
        }
        // accion que muestra la pagina principal
        public  async  Task<IActionResult> Index(int? page)
        {
            int pageSize = 1;
            int pageNumber = (page ?? 1);
            var categoria = await contexto.Categorias.OrderBy(c => c.Nombre).ToPagedListAsync(pageNumber, pageSize);
            return View(categoria);
        }

        // accion que muestra los datos 
        public async Task<IActionResult> Details(int id)
        {
            var categoria = await contexto.Categorias.SingleOrDefaultAsync(c => c.Id == c.Id);
            return View(categoria);
        }

        // muestra el formulario de crear
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                contexto.Categorias.Add(categoria);
                await contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(categoria);
        }

        // GET: CategoriaController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var categoria = await contexto.Categorias.SingleOrDefaultAsync(c => c.Id == c.Id);
            return View(categoria);
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var temp = await contexto.Categorias.SingleOrDefaultAsync(c => c.Id == categoria.Id);
                temp.Nombre = categoria.Nombre;
                temp.DescripcionCategoria = categoria.DescripcionCategoria;

                contexto.Categorias.Update(temp);
                await contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(categoria);
        }

        // metodo que muestra el formulario para eliminar un registro
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await contexto.Categorias.SingleOrDefaultAsync(c => c.Id == id);
            return View(contexto);
        }

        // metodo que recibe los datos y los elimina
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Delete(int id, Categoria categoria)
        {
            var temp = await contexto.Categorias.SingleOrDefaultAsync(c => c.Id == categoria.Id);

            if (temp! == null)
            {
                contexto.Categorias.Remove(temp);
                await contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(temp);
        }
    }
}
