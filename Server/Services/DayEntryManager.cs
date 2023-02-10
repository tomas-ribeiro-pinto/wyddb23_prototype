using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BlazorWYDDB23.Server.Interfaces;
using BlazorWYDDB23.Server.Data;
using BlazorWYDDB23.Shared.Models;

namespace BlazorWYDDB23.Server.Services
{
	public class DayEntryManager : IDayEntry
	{
        readonly ApplicationDbContext _dbContext;

        public DayEntryManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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

