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
        public string EventDescription { get; set; }
        // public string EventCategory { get; set; }
        // public string EventType { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime StartDateTime { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime EndDateTime { get; set; }

        // !-- Adding New Fields --!

        //public int OriginatorId {  get; set; } // same as userId

        //public string OriginatorName { get; set; } // get value from userId key

        //public List<int> Attendees { get; set; } // list of userIds attending meeting


        public AddEventViewModel()
        {

        }
    }
}
