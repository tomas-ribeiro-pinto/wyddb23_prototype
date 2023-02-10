using System;
using BlazorWYDDB23.Shared.Models;

namespace BlazorWYDDB23.Server.Interfaces
{
	public interface IDay
	{
        public List<Day> GetDayDetails();
        public void AddDay(Day day);
        public void UpdateDayDetails(Day day);
        public Day GetDayData(int id);
        public void DeleteDay(int id);
    }
}

