using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskAllWebbedUp.Models;

namespace MegaDeskAllWebbedUp.Pages.Quotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskAllWebbedUp.Models.MegaDeskAllWebbedUpContext _context;

        public IndexModel(MegaDeskAllWebbedUp.Models.MegaDeskAllWebbedUpContext context)
        {
            _context = context;
        }

        public IList<Quote> Quote { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }


        public async Task OnGetAsync(string sortOrder)
        {
            //Quote = await _context.Quote.ToListAsync();

            IQueryable<Quote> quoteQuery = from q in _context.Quote
                                           select q;

            if (!string.IsNullOrEmpty(SearchString))
            {
                quoteQuery = quoteQuery.Where(s => s.Name.Contains(SearchString));
            }


            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "name_desc":
                    quoteQuery = quoteQuery.OrderByDescending(x => x.Name);
                    break;
                case "Date":
                    quoteQuery = quoteQuery.OrderBy(x => x.DateAdded);
                    break;
                case "date_desc":
                    quoteQuery = quoteQuery.OrderByDescending(x => x.DateAdded);
                    break;
                default:
                    quoteQuery = quoteQuery.OrderBy(x => x.Name);
                    break;
            }

            Quote = await quoteQuery.ToListAsync();
        }
    }
}
