using System;
using BlazorWYDDB23.Shared.Models;

namespace BlazorWYDDB23.Server.Interfaces
{
	public interface IDayEntry
	{
        public List<DayEntry> GetDayEntryDetails();
        public void AddDayEntry(DayEntry dayEntry);
        public void UpdateDayEntryDetails(DayEntry dayEntry);
        public DayEntry GetDayEntryData(int id);
        public void DeleteDayEntry(int id);
    }
}

