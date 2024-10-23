﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anton_Cosmina_Lab2.Data;
using Anton_Cosmina_Lab2.Models;

namespace Anton_Cosmina_Lab2.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly Anton_Cosmina_Lab2.Data.Anton_Cosmina_Lab2Context _context;

        public DetailsModel(Anton_Cosmina_Lab2.Data.Anton_Cosmina_Lab2Context context)
        {
            _context = context;
        }

        public Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Author.FirstOrDefaultAsync(m => m.ID == id);
            if (author == null)
            {
                return NotFound();
            }
            else
            {
                Author = author;
            }
            return Page();
        }
    }
}
