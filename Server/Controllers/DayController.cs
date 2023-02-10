using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorWYDDB23.Server.Data;
using BlazorWYDDB23.Server.Interfaces;
using BlazorWYDDB23.Shared.Models;

namespace BlazorWYDDB23.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayController : ControllerBase
    {
        private readonly IDay _IDay;
        public DayController(IDay iDay)
        {
            _IDay = iDay;
        }
        [HttpGet]
        public async Task<List<Day>> Get()
        {
            return await Task.FromResult(_IDay.GetDayDetails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Day day = _IDay.GetDayData(id);
            if (day != null)
            {
                return Ok(day);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(Day day)
        {
            _IDay.AddDay(day);
        }
        [HttpPut]
        public void Put(Day day)
        {
            _IDay.UpdateDayDetails(day);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IDay.DeleteDay(id);
            return Ok();
        }
    }
}

