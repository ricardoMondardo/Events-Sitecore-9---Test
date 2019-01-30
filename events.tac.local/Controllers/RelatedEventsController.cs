using events.tac.local.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class RelatedEventsController : Controller
    {
        private readonly RelatedEventsProvider _provider;

        public RelatedEventsController() : this(new RelatedEventsProvider())
        {

        }

        public RelatedEventsController(RelatedEventsProvider provider)
        {
            _provider = provider;
        }
        public ActionResult Index()
        {
            var model = _provider.GetRelatedEvents();

            return View("~/views/RelatedEvents/Index.cshtml", model);
        }
    }
}