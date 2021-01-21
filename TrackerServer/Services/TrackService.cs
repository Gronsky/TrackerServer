using System;
using System.Collections.Generic;
using MongoDB.Driver;
using TrackerServer.Models;

namespace TrackerServer.Services
{
    public class TrackService
    {
        private readonly IMongoCollection<Track> _tracks;

        public TrackService(ITrackerDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tracks = database.GetCollection<Track>(settings.TracksCollectionName);
        }

        public List<Track> Get() =>
            _tracks.Find(track => true).ToList();

        public Track Get(string id) =>
            _tracks.Find<Track>(track => track.Id == id).FirstOrDefault();

        public Track Create(Track track)
        {
            _tracks.InsertOne(track);
            return track;
        }

        public void Update(string id, Track trackIn) =>
            _tracks.ReplaceOne(track => track.Id == id, trackIn);

        public void Remove(Track bookIn) =>
            _tracks.DeleteOne(track => track.Id == bookIn.Id);

        public void Remove(string id) =>
            _tracks.DeleteOne(track => track.Id == id);
    }
}
