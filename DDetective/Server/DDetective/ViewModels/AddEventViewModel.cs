//using System;
//using System.ComponentModel.DataAnnotations;
//using DDetective.Models;

//namespace DDetective.ViewModels
//{
//    public class AddEventViewModel
//    {
//        [Key]
//        public int EventId { get; set; }

//        [Required]
//        public string EventName { get; set; }

//        [Required]
//        public string EventDescription { get; set; }

//        public bool AllDayEvent { get; set; }

//        [Required]
//        [DataType(DataType.DateTime)]
//        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
//        public DateTime StartDate { get; set; }

//        [Required]
//        [DataType(DataType.DateTime)]
//        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
//        public DateTime StartTime { get; set; }

//        [Required]
//        [DataType(DataType.DateTime)]
//        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
//        public DateTime EndDate { get; set; }

//        [Required]
//        [DataType(DataType.DateTime)]
//        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
//        public DateTime EndTime { get; set; }

//        public AddEventViewModel () { }
//    }
       
//}