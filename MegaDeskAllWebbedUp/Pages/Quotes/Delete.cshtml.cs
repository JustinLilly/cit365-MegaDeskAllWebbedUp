﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskAllWebbedUp.Models;

namespace MegaDeskAllWebbedUp.Pages.Quotes
{
    public class DeleteModel : PageModel
    {
        private readonly MegaDeskAllWebbedUp.Models.MegaDeskAllWebbedUpContext _context;

        public DeleteModel(MegaDeskAllWebbedUp.Models.MegaDeskAllWebbedUpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Quote Quote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quote = await _context.Quote.FirstOrDefaultAsync(m => m.ID == id);

            if (Quote == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quote = await _context.Quote.FindAsync(id);

            if (Quote != null)
            {
                _context.Quote.Remove(Quote);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
