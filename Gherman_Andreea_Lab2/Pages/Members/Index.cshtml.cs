using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gherman_Andreea_Lab2.Models;

namespace Gherman_Andreea_Lab2.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly Gherman_Andreea_Lab2Context _context;

        public IndexModel(Gherman_Andreea_Lab2Context context)
        {
            _context = context;
        }

        public IList<Member> Member { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Member = await _context.Member.ToListAsync();
        }
    }
}
