using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bageriet.Models;
using Bageriet.ViewModels;
using Bageriet.Context;
using Bageriet.Interfaces;
using Bageriet.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Bageriet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContacts _contacts;
        public HomeController(ILogger<HomeController> logger, IContacts contacts)
        {
            _logger = logger;
            _contacts = contacts;
        }

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            ViewBag.PageTitle = "Bageriet";
            return View();
        }

        [Route("Login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            ViewBag.PageTitle = "Registrering";
            return View();
        }

        [Route("Contacts")]
        [Route("Home/Contacts")]
        public IActionResult Contacts()
        {
            ViewBag.PageTitle = "Kontakt informaton";
            return View(GetContact(1));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult NewContacts(ContactsViewModel model)
        {
            var contacts = new Contacts
            {
                Title = model.Title,
                Address = model.Address,
                City = model.City,
                Zip = model.Zip,
                Phone = model.Phone,
                Email = model.Email
            };
            _contacts.Add(contacts);

            return Json(_contacts.Save());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult EditContacts(ContactsViewModel model)
        {
            if (model == null)
                return Json(false);
            _contacts.Edit(model);
            return Json(new { success = _contacts.Save() });
        }

        public Contacts GetContact(int id)
        {
            return _contacts.GetContact(id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
