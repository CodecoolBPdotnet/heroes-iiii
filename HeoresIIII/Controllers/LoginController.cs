using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HeroesIIII.Models;
using HeroesIIII.Models.Generators;

namespace HeroesIIII.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApiContext _context;
        private readonly Game _game;

        public LoginController(ApiContext context, Game game)
        {
            _context = context;
            _game = game;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            collection.TryGetValue("Name", out var name);
            collection.TryGetValue("email", out var email);
            var createdAccount = new Account
            {
                Email = email,
                Name = name
            };
            var generator = new HeroGenerator();
            createdAccount.Hero = generator.GenerateNewRandomHero();
            _game.Account = createdAccount;
            _game.Hero = createdAccount.Hero;
            _context.Accounts.Add(createdAccount);
            _context.SaveChanges();
            return Redirect("/game");
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}