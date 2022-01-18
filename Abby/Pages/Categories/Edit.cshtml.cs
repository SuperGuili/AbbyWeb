using Abby.Data;
using Abby.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int Id)
        {
            Category = _db.Categories.SingleOrDefault(c => c.Id == Id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder)
            {
                ModelState.AddModelError("Category.Name", "The Name cannot be igual to Display Order");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);

                await _db.SaveChangesAsync();

                TempData["success"] = "Category Edited Successfully";

                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
