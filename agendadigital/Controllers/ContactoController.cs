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
        public ActionResult Details(int id)
        {
            return View();
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
            return View();
        }

        // POST: ContactoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ContactoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactoController/Delete/5
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
