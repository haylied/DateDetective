using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DDetective.Models
{
    public class AddEventModel
    {
        [Key]
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }



        ////////////////////////////////////////////
        // public string EventCategory { get; set; }
        // public string EventType { get; set; }
        ////////////////////////////////////////////



        // DATE FIELDS:
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateEnd { get; set; }


        // TIME FIELDS:
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }


        public AddEventModel(int eventId, string eventName, string eventDescription, DateTime dateStart, DateTime dateEnd, DateTime timeStart, DateTime timeEnd)
        {
            EventId = eventId;
            EventName = eventName;
            EventDescription = eventDescription;
            DateStart = dateStart;
            DateEnd = dateEnd;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
        }

        public AddEventModel() { }
}

}
