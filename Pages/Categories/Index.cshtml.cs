using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anton_Cosmina_Lab2.Data;
using Anton_Cosmina_Lab2.Models;
using Anton_Cosmina_Lab2.Models.ViewModels;

namespace Anton_Cosmina_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Anton_Cosmina_Lab2.Data.Anton_Cosmina_Lab2Context _context;

        public IndexModel(Anton_Cosmina_Lab2.Data.Anton_Cosmina_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryData { get; set; } = new CategoryIndexData();
        public int? SelectedCategoryId { get; set; }

        public async Task OnGetAsync(int? id)
        {
            // Încarcă toate categoriile și cărțile asociate prin BookCategories
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                .ThenInclude(bc => bc.Book)
                .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            // Dacă o categorie este selectată, încarcă doar cărțile din acea categorie
            if (id != null)
            {
                SelectedCategoryId = id.Value;
                var selectedCategory = CategoryData.Categories
                    .FirstOrDefault(c => c.ID == id.Value);

                CategoryData.Books = selectedCategory?.BookCategories.Select(bc => bc.Book) ?? new List<Book>();
            }
        }
    }
}
