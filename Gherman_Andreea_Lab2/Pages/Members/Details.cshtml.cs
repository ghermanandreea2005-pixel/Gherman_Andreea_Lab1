using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gherman_Andreea_Lab2.Models;

namespace Gherman_Andreea_Lab2.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly Gherman_Andreea_Lab2Context _context;

        public DetailsModel(Gherman_Andreea_Lab2Context context)
        {
            _context = context;
        }

        public Member Member { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.ID == id);

            if (member is not null)
            {
                Member = member;
                return Page();
            }

            return NotFound();
        }
    }
}
