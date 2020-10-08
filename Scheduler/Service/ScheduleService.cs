using Scheduler.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler.Services
{
    public class ScheduleService
    {
        private readonly IMongoCollection<Schedule> _schedules;

        public ScheduleService(ISchedulerDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            //var client = new MongoClient("mongodb+srv://frida:solsJP9rzPajSPqJ@cluster0.m8cdz.azure.mongodb.net/FridA?retryWrites=true&w=majority&sslVerifyCertificate=false");
           
            //var database = client.GetDatabase("test");

            var database = client.GetDatabase(settings.DatabaseName);

            _schedules = database.GetCollection<Schedule>(settings.SchedulerCollectionName);
        }

        public List<Schedule> Get() =>
            _schedules.Find(schedule => true).ToList();

        public Schedule Get(string id) =>
            _schedules.Find<Schedule>(schedule => schedule.Id == id).FirstOrDefault();

        public Schedule Create(Schedule schedule)
        {
            _schedules.InsertOne(schedule);
            return schedule;
        }

        public void Update(string id, Schedule scheduleIn) =>
            _schedules.ReplaceOne(schedule => schedule.Id == id, scheduleIn);

        public void Remove(Schedule scheduleIn) =>
            _schedules.DeleteOne(schedule => schedule.Id == scheduleIn.Id);

        public void Remove(string id) =>
            _schedules.DeleteOne(schedule => schedule.Id == id);
    }
}