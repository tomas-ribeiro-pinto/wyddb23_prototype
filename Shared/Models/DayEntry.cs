using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWYDDB23.Shared.Models
{
    public class DayEntry
    {
        [Key]
        public int DayEntryId { get; set; }

        [Required, MaxLength(40, ErrorMessage = "{0} is too long")]
        public string EntryTitle { get; set; } = String.Empty;
        [Required, MaxLength(40, ErrorMessage = "{0} is too long")]
        public string Location { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid Date Format")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH/mm}")]
        public DateTime Date { get; set; }

        [Required]
        public int DayId { get; set; }
        public virtual Day? Day { get; set; }
	}
}

