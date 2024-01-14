using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FeedbackApp.Data;
using FeedbackApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApp.Pages.Reviews
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly FeedbackAppContext _context;

        public CreateModel(FeedbackAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; }

        public IActionResult OnGet()

        {

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("OnPostAsync Start");

            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine("ModelState is not valid");

                    // Afișează detalii despre erori în consolă
                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var error in modelState.Errors)
                        {
                            Console.WriteLine($"Error: {error.ErrorMessage}");
                        }
                    }

                    return Page();
                }

                _context.Review.Add(Review);
                await _context.SaveChangesAsync();

                Console.WriteLine("Review added successfully");
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return Page();
            }
        }

    }
}





