﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicLibraryWebAPI.Data;
using MusicLibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        ApplicationDbContext _context;

        public SongController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<MusicController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        [HttpGet]
        public IActionResult Get()
        {
            var song = _context.Songs;
            return Ok(song);
            //return _context.GetType(song);
        }
        // GET api/<MusicController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //query the db for the song with the id of our id parameter
            //pass found song into ok()
            return Ok();
        }

        //POST api/<MusicController>
        [HttpPost]
        public IActionResult Post([FromBody] Song song)
        {
            try
            {
                _context.Songs.Add(song);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<MusicController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MusicController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
