using System;
using System.ComponentModel.DataAnnotations;

namespace DDetective.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public string EventName { get; set; }

       //public string EventDescription { get; set; }

        public bool AllDayEvent { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime? EndTime { get; set; }

        //public int EventOriginatorId {  get; set; } // same as ProfileId

        //public List<int> Attendees { get; set; } // list of ProfileIds attending meeting

        public Event() { }

        public Event(int eventId, string eventName, DateTime startDate, DateTime startTime, DateTime endDate, DateTime endTime)
        {
            EventId = eventId;
            EventName = eventName;
            //EventDescription = eventDescription;
            AllDayEvent = false;
            StartDate = startDate;
            StartTime = startTime;
            EndDate = endDate;
            EndTime = endTime;
            //EventOriginatorId = eventOriginatorId;
        }

    }
}