using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TrackerServer.Models;
using TrackerServer.Services;

namespace TrackerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrackController : ControllerBase 
    {
        private readonly TrackService _trackService;

        public TrackController(TrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet]
        public ActionResult<List<Track>> Get() =>
            _trackService.Get();


        [HttpGet("{id:length(24)}", Name = "GetTrack")]
        public ActionResult<Track> Get(string id)
        {
            var track = _trackService.Get(id);

            if (track == null)
            {
                return NotFound();
            }

            return track;
        }

        [HttpPost]
        public ActionResult<Track> Post(Track track)
        {
            var createdTrack = _trackService.Create(track);

            return CreatedAtRoute("GetTrack", new { id = track.Id.ToString() }, track);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Track trackIn)
        {
            var track = _trackService.Get(id);

            if (track == null)
            {
                return NotFound();
            }

            _trackService.Update(id, trackIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var track = _trackService.Get(id);

            if (track == null)
            {
                return NotFound();
            }

            _trackService.Remove(track.Id);

            return NoContent();
        }
    }
}
