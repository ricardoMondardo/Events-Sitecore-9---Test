﻿using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events.tac.local.Models
{
    public class EventDetails : SearchResultItem
    {
        public string ContentHeading { get; set; }
        public string ContentIntro { get; set; }
        public DateTime StartDate { get; set; }
        public HtmlString EventImage {
            get
            {
                var obj = GetItem();
                return new HtmlString(
                    FieldRenderer.Render(obj, "EventImage", "DisableWebEditing=true & mw = 150"));
            }
        }

    }
}