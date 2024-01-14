using System;
using System.ComponentModel.DataAnnotations;

namespace FeedbackApp.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        [Required(ErrorMessage = "Please enter a review.")]
        public string Comment { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int FoodRating { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int ServiceRating { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int AtmosphereRating { get; set; }

        public DateTime DatePosted { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}


