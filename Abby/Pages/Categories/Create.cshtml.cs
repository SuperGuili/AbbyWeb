using Abby.Data;
using Abby.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder)
            {
                ModelState.AddModelError("Category.Name", "The Name cannot be igual to Display Order");
            }

            if (ModelState.IsValid)
            {
                await _db.Categories.AddAsync(Category);

                await _db.SaveChangesAsync();

                TempData["success"] = "Category Created Successfully";

                return RedirectToPage("Index");
            }

            return Page();
            
        }
    }
}
