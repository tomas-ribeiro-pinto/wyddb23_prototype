using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorWYDDB23.Shared.Models
{
	public class Day
	{
		[Key]
		public int DayId { get; set; }

		[Required]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid Date Format")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM}")]
        public DateTime Date { get; set; }

		public virtual List<DayEntry> Entries { get; set; } = new();
	}
}

