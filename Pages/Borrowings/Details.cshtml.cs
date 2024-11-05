using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anton_Cosmina_Lab2.Data;
using Anton_Cosmina_Lab2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Anton_Cosmina_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Anton_Cosmina_Lab2.Data.Anton_Cosmina_Lab2Context _context;

        public DetailsModel(Anton_Cosmina_Lab2.Data.Anton_Cosmina_Lab2Context context)
        {
            _context = context;
        }

        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing.FirstOrDefaultAsync(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            else
            {
                Borrowing = borrowing;
            }

            var bookList = _context.Book
               .Include(b => b.Author)
               .Select(x => new
               {
                   x.ID,
                   BookFullName = x.Title + " - " + x.Author.LastName + " " + x.Author.FirstName
               });
            ViewData["BookID"] = new SelectList(bookList, "ID", "BookFullName");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            
            return Page();
        }
    }
}
