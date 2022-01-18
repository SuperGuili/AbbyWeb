using Abby.Data;
using Abby.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int Id)
        {
            Category = _db.Categories.SingleOrDefault(c => c.Id == Id);
        }

        public async Task<IActionResult> OnPost()
        {

            Category categoryFromDb = await _db.Categories.FindAsync(Category.Id);

            if (categoryFromDb != null)
            {
                _db.Categories.Remove(categoryFromDb);

                await _db.SaveChangesAsync();

                TempData["success"] = "Category Deleted Successfully";

                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
