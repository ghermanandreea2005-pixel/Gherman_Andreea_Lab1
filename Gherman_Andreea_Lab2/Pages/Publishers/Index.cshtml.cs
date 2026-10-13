using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gherman_Andreea_Lab2.Models;

namespace Gherman_Andreea_Lab2.Pages_Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Gherman_Andreea_Lab2Context _context;

        public IndexModel(Gherman_Andreea_Lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}
