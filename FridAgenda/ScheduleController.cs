﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scheduler
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {

        private readonly ScheduleService _scheduleService;

        public ScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }



        // GET: api/<ScheduleController>
        [HttpGet]
        public ActionResult<List<Schedule>> Get() =>
            _scheduleService.Get();

        // GET api/<ScheduleController>/5
        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Schedule> Get(string id)
        {
            var book = _scheduleService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // POST api/<ScheduleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ScheduleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ScheduleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
