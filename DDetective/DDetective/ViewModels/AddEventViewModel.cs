using System;
using System.ComponentModel.DataAnnotations;
using DDetective.Models;

namespace DDetective.ViewModels
{
    public class AddEventViewModel
    {
        //[Key]
        //[Required(ErrorMessage)]
        public int? EventId { get; set; }
        public string? EventName { get; set; }
        public string? EventDescription { get; set; }
        // public string EventCategory { get; set; }
        // public string EventType { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }

        public AddEventViewModel()
        {
        }
    }
}
