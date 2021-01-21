using System;
using Microsoft.EntityFrameworkCore;

namespace TrackerServer.Models
{
    public class TrackContext : DbContext
    {
        public TrackContext(DbContextOptions<TrackContext> options) : base(options)
        {
        }

        public DbSet<Track> Tracks { get; set; }
    }
}
