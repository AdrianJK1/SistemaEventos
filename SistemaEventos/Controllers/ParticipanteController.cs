using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEventos.Models;
using X.PagedList;

namespace SistemaEventos.Controllers
{
    public class ParticipanteController : Controller
    {
        private readonly ContextoDeDatos contexto;
        public ParticipanteController(ContextoDeDatos contexto)
        {
            this.contexto = contexto;
        }
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10; //numero de paginas
            int pageNumber = (page ?? 1); //pagina actual

            var participantes = await contexto.Participantes.OrderByDescending(p => p.Id).ToPagedListAsync(pageNumber, pageSize);
            return View(participantes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var participante = await contexto.Participantes.SingleOrDefaultAsync(p => p.Id == id);

            return View(participante);
        }


        //Formulario
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Participante participante)
        {

            if (ModelState.IsValid)
            {
                contexto.Participantes.Add(participante);
                await contexto.SaveChangesAsync();
                TempData["SuccessMessage"] = "Inscripción exitosa";
                return RedirectToAction("IndexUsuario", "Evento");
            }
            else
                return View(participante);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var participante = await contexto.Participantes.SingleOrDefaultAsync(p => p.Id == id);
            return View(participante);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Participante participante)
        {
            if (ModelState.IsValid)
            {
                var tem = await contexto.Participantes.SingleOrDefaultAsync(p => p.Id == participante.Id);
                tem.Nombre = participante.Nombre;
                tem.Apellido = participante.Apellido;
                tem.Email = participante.Email;
                tem.Telefono = participante.Telefono;

                contexto.Participantes.Update(tem);
                await contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(participante);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var participante = await contexto.Participantes.SingleOrDefaultAsync(p => p.Id == id);
            return View(participante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Participante participante)
        {
            var tem = await contexto.Participantes.SingleOrDefaultAsync(p => p.Id == participante.Id);

            if (tem != null)
            {
                contexto.Participantes.Remove(tem);
                await contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(tem);
        }
    }
}
