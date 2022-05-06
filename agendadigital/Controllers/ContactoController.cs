using agendadigital.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using agendadigital.entidades;
using Microsoft.EntityFrameworkCore;

namespace agendadigital.Controllers
{
    public class ContactoController : Controller
    { 

        private ApplicationDbContext dbContext;
        public ContactoController (ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
    
        // GET: ContactoController
        public async Task<ActionResult> Index()
        {
            var lista = await dbContext.Contactos.ToListAsync();
            return View(lista);
        }

        // GET: ContactoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Contacto contacto = await dbContext.Contactos.FindAsync(id);
            return View(contacto);
        }

        // GET: ContactoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contacto contacto)
        {
            try
            {
                dbContext.Add(contacto);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactoController/Edit/5
        public ActionResult Edit(int id)
        {

            var contacto = dbContext.Contactos.Find(id);
            return View(contacto);
        }

        // POST: ContactoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Contacto contacto)
        {
            try
            {
                if (id != contacto.Id)
                {
                    new Exception("El Id no coincide");
                }
                dbContext.Update(contacto);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(contacto);
            }
        }

        // GET: ContactoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var contacto = await dbContext.Contactos.FindAsync(id);
            return View(contacto);
        }

        // POST: ContactoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Contacto contacto)
        {
            try
            {
                dbContext.Remove(contacto);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(contacto);
            }
        }
    }
}
