﻿using System.Web.Mvc;
using AgeRanger.Domain.Services;

namespace AgeRanger.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService personService;

        public HomeController(IPersonService personService)
        {
            this.personService = personService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}