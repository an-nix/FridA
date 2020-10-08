
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler
{
    public class ScheduleService
    {
        private readonly IMongoCollection<Schedule> _schedule;

        public ScheduleService(IScheduleDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _schedule = database.GetCollection<Schedule>(settings.ScheduleCollectionName);
        }

        public List<Schedule> Get() =>
            _schedule.Find(book => true).ToList();

        public Schedule Get(string id) =>
            _schedule.Find<Schedule>(book => book.Id == id).FirstOrDefault();

        public Schedule Create(Schedule schedule)
        {
            _schedule.InsertOne(schedule);
            return schedule;
        }

        public void Update(string id, Schedule bookIn) =>
            _schedule.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Schedule bookIn) =>
            _schedule.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _schedule.DeleteOne(book => book.Id == id);
    }
}