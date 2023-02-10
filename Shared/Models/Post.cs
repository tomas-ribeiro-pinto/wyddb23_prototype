using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorWYDDB23.Shared.Models
{
	public class Post
	{
		[Key]
		public int ID { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = String.Empty;
        [Required]
        [StringLength(50, ErrorMessage = "Message is too long.")]
        public string Message { get; set; } = String.Empty;
    }
}

