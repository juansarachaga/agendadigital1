using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using agendadigital.EntityFramework;
using Microsoft.EntityFrameworkCore;
using agendadigital.entidades;

namespace agendadigital.Controllers
{
    public class UsuarioController : Controller
    {
        private ApplicationDbContext dbContext;
        public UsuarioController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }


        // GET: UsuarioController
        public async Task<ActionResult> Index()
        {
            var lista = await dbContext.Usuarios.ToListAsync();
            return View(lista);
        }

        // GET: UsuarioController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Usuario usuario = await dbContext.Usuarios.FindAsync(id);
            return View(usuario);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Usuario usuario)
        {
            try
            {
                dbContext.Add(usuario);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            var usuario = dbContext.Usuarios.Find(id);
            return View(usuario);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Usuario usuario)
        {
            try
            {
                dbContext.Update(usuario);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
