using System;
using System.ComponentModel.DataAnnotations;
using DDetective.Models;

namespace DDetective.ViewModels
{
    public class AddEventViewModel
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [MinLength(3)]
        public string EventName { get; set; }

        [Required]
        public string EventDescription { get; set; }}

        public bool AllDayEvent { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime StartTime { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime EndDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime StartTime { get; set; }


         public AddEventViewModel()
         {

         }

         public AddEventViewModel(int eventId, string eventName, string eventDescription, DateTime startDate, DateTime startTime, DateTime endDate, DateTime endTime, int eventOriginatorId)
         {
            AddEventViewModel.EventId = eventId;
            EventName = eventName;
            EventDescription = eventDescription;
            AllDayEvent = false;
            StartDate = startDate;
            StartTime = startTime;
            EndDate = endDate;
            EndTime = endTime;
            EventOriginatorId = eventOriginatorId;
         }
}