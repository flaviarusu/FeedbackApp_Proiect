using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FeedbackApp.Data;
using FeedbackApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace FeedbackApp.Pages.Reviews
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly FeedbackApp.Data.FeedbackAppContext _context;

        public IndexModel(FeedbackApp.Data.FeedbackAppContext context)
        {
            _context = context;
        }

        public IList<Review> Review { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Review != null)
            {
                Review = await _context.Review
                .Include(r => r.Client).ToListAsync();
            }
        }
    }
}
