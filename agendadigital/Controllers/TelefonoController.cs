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
        public ActionResult Details(int id)
        {
            return View();
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
            return View();
        }

        // POST: TelefonoController/Edit/5
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

        // GET: TelefonoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TelefonoController/Delete/5
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
