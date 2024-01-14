using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FeedbackApp.Models;

namespace FeedbackApp.Data
{
    public class FeedbackAppContext : DbContext
    {
        public FeedbackAppContext (DbContextOptions<FeedbackAppContext> options)
            : base(options)
        {
        }

        public DbSet<FeedbackApp.Models.Client> Client { get; set; } = default!;

        public DbSet<FeedbackApp.Models.Review>? Review { get; set; }
    }
}
