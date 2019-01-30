using events.tac.local.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class NavigationController : Controller
    {
        private readonly NavigationBuilder _navigationBuilder;

        public NavigationController() : this(new NavigationBuilder()){}

        public NavigationController(NavigationBuilder navigationBuilder)
        {
            _navigationBuilder = navigationBuilder;
        }
        public ActionResult Index()
        {
            return View(_navigationBuilder.Build());
        }
    }
}