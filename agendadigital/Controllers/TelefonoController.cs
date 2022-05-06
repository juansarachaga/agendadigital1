﻿using agendadigital.entidades;
using agendadigital.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agendadigital.Controllers
{
    public class TelefonoController : Controller
    {
        private ApplicationDbContext dbContext;
        public TelefonoController(ApplicationDbContext applicationDbContext)
        {
            dbContext =  applicationDbContext;
        }
        // GET: TelefonoController
        public async Task<ActionResult> Index()
        {
            
            var lista = await dbContext.Telefonos.ToListAsync();
            return View(lista);
        }

        // GET: TelefonoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Telefono telefono = await dbContext.Telefonos.FindAsync(id);
            return View(telefono);
        }

        // GET: TelefonoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TelefonoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Telefono telefono)
        {
            try
            {
                dbContext.Add(telefono);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TelefonoController/Edit/5
        public ActionResult Edit(int id)
        {
            var telefono = dbContext.Telefonos.Find(id);
            return View(telefono);
        }

        // POST: TelefonoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Telefono telefono)
        {
            try
            {
                if (id != telefono.Id)
                {
                    new Exception("El Id no coincide");
                }
                dbContext.Update(telefono);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(telefono);
            }
        }

        // GET: TelefonoController/Delete/5
        public ActionResult Delete(int id)
        {
            var telefono = dbContext.Telefonos.Find(id);
            return View(telefono);
        }

        // POST: TelefonoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Telefono telefono)
        {
            try
            {
                dbContext.Remove(telefono);
                await dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(telefono);
            }
        }
    }
}
