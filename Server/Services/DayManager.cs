using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BlazorWYDDB23.Server.Interfaces;
using BlazorWYDDB23.Server.Data;
using BlazorWYDDB23.Shared.Models;

namespace BlazorWYDDB23.Server.Services
{
	public class DayManager : IDay
	{
        readonly ApplicationDbContext _dbContext;
        public DayManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //To Get all day details
        public List<Day> GetDayDetails()
        {
            try
            {
                return _dbContext.Days.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new day record
        public void AddDay(Day day)
        {
            try
            {
                _dbContext.Days.Add(day);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar day
        public void UpdateDayDetails(Day day)
        {
            try
            {
                _dbContext.Entry(day).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular day
        public Day GetDayData(int id)
        {
            try
            {
                Day? day = _dbContext.Days.Find(id);
                if (day != null)
                {
                    return day;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular day
        public void DeleteDay(int id)
        {
            try
            {
                Day? day = _dbContext.Days.Find(id);
                if (day != null)
                {
                    _dbContext.Days.Remove(day);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<DayEntry> GetDayEntryDetails()
        {
            try
            {
                return _dbContext.DayEntries.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void AddDayEntry(DayEntry dayEntry)
        {
            try
            {
                _dbContext.DayEntries.Add(dayEntry);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateDayEntryDetails(DayEntry dayEntry)
        {
            try
            {
                _dbContext.Entry(dayEntry).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public DayEntry GetDayEntryData(int id)
        {
            try
            {
                DayEntry? dayEntry = _dbContext.DayEntries.Find(id);
                if (dayEntry != null)
                {
                    return dayEntry;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void DeleteDayEntry(int id)
        {
            try
            {
                DayEntry? dayEntry = _dbContext.DayEntries.Find(id);
                if (dayEntry != null)
                {
                    _dbContext.DayEntries.Remove(dayEntry);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

