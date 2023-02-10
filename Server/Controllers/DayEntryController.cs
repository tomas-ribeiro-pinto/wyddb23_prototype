using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorWYDDB23.Server.Data;
using BlazorWYDDB23.Server.Interfaces;
using BlazorWYDDB23.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BlazorWYDDB23.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayEntryController : ControllerBase
    {
        private readonly IDayEntry _IDay;
        public DayEntryController(IDayEntry iDay)
        {
            _IDay = iDay;
        }
        [HttpGet]
        public async Task<List<DayEntry>> Get()
        {
            return await Task.FromResult(_IDay.GetDayEntryDetails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DayEntry dayEntry = _IDay.GetDayEntryData(id);
            if (dayEntry != null)
            {
                return Ok(dayEntry);
            }
            return NotFound();
        }
        [HttpPost]
        //[Authorize(Roles = "Administrator")]
        public void Post(DayEntry dayEntry)
        {
            _IDay.AddDayEntry(dayEntry);
        }
        [HttpPut]
        public void Put(DayEntry dayEntry)
        {
            _IDay.UpdateDayEntryDetails(dayEntry);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IDay.DeleteDayEntry(id);
            return Ok();
        }
    }
}

