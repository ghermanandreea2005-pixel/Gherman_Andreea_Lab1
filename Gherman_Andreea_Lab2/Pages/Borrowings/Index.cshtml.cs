using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gherman_Andreea_Lab2.Data;
using Gherman_Andreea_Lab2.Models;

namespace Gherman_Andreea_Lab2.Pages.Borrowings
{
    public class IndexModel : PageModel
    {
        private readonly Gherman_Andreea_Lab2Context _context;

        public IndexModel(Gherman_Andreea_Lab2Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Borrowing != null)
            {
                Borrowing = await _context.Borrowing
                    .Include(b => b.Book)
                    .ThenInclude(b => b.Author)
                    .Include(b => b.Member)
                    .ToListAsync();
            }
        }
    }
}