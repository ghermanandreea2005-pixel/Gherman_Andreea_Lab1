using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gherman_Andreea_Lab2.Data;
using Gherman_Andreea_Lab2.Models;

namespace Gherman_Andreea_Lab2.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly Gherman_Andreea_Lab2Context _context;

        public EditModel(Gherman_Andreea_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
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

            Borrowing = borrowing;

            var bookList = _context.Book
                .Include(b => b.Author)
                .Select(x => new
                {
                    x.ID,
                    BookFullName = x.Title + " - " + x.Author.LastName + " " + x.Author.FirstName
                });

            ViewData["BookID"] = new SelectList(bookList, "ID", "BookFullName", borrowing.BookID);
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName", borrowing.MemberID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var bookList = _context.Book
                    .Include(b => b.Author)
                    .Select(x => new
                    {
                        x.ID,
                        BookFullName = x.Title + " - " + x.Author.LastName + " " + x.Author.FirstName
                    });

                ViewData["BookID"] = new SelectList(bookList, "ID", "BookFullName", Borrowing.BookID);
                ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName", Borrowing.MemberID);
                return Page();
            }

            _context.Attach(Borrowing).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}