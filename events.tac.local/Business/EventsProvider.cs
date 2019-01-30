﻿using events.tac.local.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.Mvc.Presentation;
using System.Linq;

namespace events.tac.local.Business
{
    public class EventsProvider
    {
        private const int PageSize = 4;
        public EventsList GetEventsList(int pageNo)
        {
            var indexname = $"sitecore_{RenderingContext.Current.ContextItem.Database.Name.ToLower()}_index";
            var index = ContentSearchManager.GetIndex(indexname);

            using (var context = index.CreateSearchContext())
            {
                var results = context.GetQueryable<EventDetails>()
                .Where(i => i.Paths.Contains(RenderingContext.Current.ContextItem.ID))
                .Where(i => i.Language ==
                RenderingContext.Current.ContextItem.Language.Name)
                .Page(pageNo, PageSize)
                .GetResults();
                return new EventsList()
                {
                    Events = results.Hits.Select(h => h.Document).ToArray(),
                    TotalResultCount = results.TotalSearchResults,
                    PageSize = PageSize
                };
            }
        }
    }
}