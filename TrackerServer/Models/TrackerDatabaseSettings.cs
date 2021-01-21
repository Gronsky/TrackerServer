using System;
namespace TrackerServer.Models
{
    public class TrackerDatabaseSettings : ITrackerDatabaseSettings
    {
        public string TracksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ITrackerDatabaseSettings
    {
        string TracksCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
