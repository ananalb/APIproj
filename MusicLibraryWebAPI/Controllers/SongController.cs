using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Get()
        {
            var songs = _context.Songs;
            return Ok(songs);           
        }
        // GET api/<MusicController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var songs = _context.Songs.Where(e => e.Id == id).FirstOrDefault();
            return Ok(songs);
        }

        //POST api/<MusicController>
        [HttpPost]
        public IActionResult Post([FromBody] Song song)
        {
            try
            {
                _context.Songs.Add(song);
                _context.SaveChanges();
                return Created("api/Song", song);
            }
            catch(Exception err)
            {
                return BadRequest(err);
            }
        }

        // PUT api/<MusicController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Song song)
        {
            try
            {
                _context.Songs.Update(song);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }

        // DELETE api/<MusicController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id )
        {

            var song = _context.Songs.Where(e => e.Id == id).FirstOrDefault();
           

            try
            {
                _context.Songs.Remove(song);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }
    }
}
