using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gherman_Andreea_Lab2.Data;
using Gherman_Andreea_Lab2.Models;

namespace Gherman_Andreea_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Gherman_Andreea_Lab2Context _context;

        public DetailsModel(Gherman_Andreea_Lab2Context context)
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

            var borrowing = await _context.Borrowing
                .Include(b => b.Member)
                .Include(b => b.Book)
                    .ThenInclude(b => b.Author)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (borrowing == null)
            {
                return NotFound();
            }

            Borrowing = borrowing;
            return Page();
        }
    }
}