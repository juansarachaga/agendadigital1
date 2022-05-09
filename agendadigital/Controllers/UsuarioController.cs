using agendadigital.entidades;
using agendadigital.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            var usuarios = await dbContext.Usuarios.Include(x => x.contacto).ToListAsync();
            return View(usuarios);
        }

        // GET: UsuarioController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Usuario usuario = await dbContext.Usuarios.FindAsync(id);
            return View(usuario);
        }

        // GET: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Usuario usuario)
        {
            ViewBag.ContactoId = new SelectList(await dbContext.Contactos.ToListAsync(), "Id", "Nombre");
           
            return View();
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
                if (id != usuario.Id)
                {
                    new Exception("El Id no coincide");
                }
                dbContext.Update(usuario);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: UsuarioController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var usuario = await dbContext.Usuarios.FindAsync(id);
            return View(usuario);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Usuario usuario)
        {
            try
            {
                dbContext.Remove(usuario);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(usuario);
            }
        }
    }
}
