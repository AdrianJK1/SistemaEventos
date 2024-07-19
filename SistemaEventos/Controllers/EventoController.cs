using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEventos.Models;
using X.PagedList;

namespace SistemaEventos.Controllers
{
    public class EventoController : Controller
    {
        private readonly ContextoDeDatos contexto;

        public EventoController(ContextoDeDatos contexto)
        {
            this.contexto = contexto;
        }
        // GET: EventoController
        public  async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var eventos = await contexto.Eventos.OrderBy(e => e.NombreEvento).ToPagedListAsync(pageNumber, pageSize);
            return View(eventos);
        }

        // GET: EventoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var eventos = await contexto.Eventos.SingleOrDefaultAsync(e => e.Id == id);
            return View(eventos);
        }

        // GET: EventoController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Evento evento)
        {
            if (ModelState.IsValid)
            {
                contexto.Eventos.Add(evento);
                await contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(evento);
        }

        // GET: EventoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var evento = await contexto.Eventos.SingleOrDefaultAsync(e => e.Id == id);
            return View(evento);
        }

        // POST: EventoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Evento evento)
        {
            if (ModelState.IsValid)
            {
                var temp = await contexto.Eventos.SingleOrDefaultAsync(e => e.Id == evento.Id);
                temp.NombreEvento = evento.NombreEvento;
                temp.DescripcionDelEvento = evento.DescripcionDelEvento;
                temp.FechaDelEvento = evento.FechaDelEvento;
                temp.Ubicacion = evento.Ubicacion;

                contexto.Eventos.Update(temp);
                await contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(evento);
        }

        // GET: EventoController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var evento = await contexto.Eventos.SingleOrDefaultAsync(e => e.Id == id);
            return View(evento);
        }

        // POST: EventoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Evento evento)
        {
            var temp = await contexto.Eventos.SingleOrDefaultAsync(e => e.Id == id);

            if (temp != null)
            {
                contexto.Eventos.Remove(temp);
                await contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(temp);

        }
    }
}
