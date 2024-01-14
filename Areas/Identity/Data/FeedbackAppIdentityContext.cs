using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApp.Data
{
    public class FeedbackAppIdentityContext : IdentityDbContext<IdentityUser>
    {
        public FeedbackAppIdentityContext(DbContextOptions<FeedbackAppIdentityContext> options)
            : base(options)
        {
        }

        // Poți adăuga aici orice configurații suplimentare, dacă este necesar
    }
}


