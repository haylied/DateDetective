using System;
using System.ComponentModel.DataAnnotations;
using DDetective.Models;

namespace DDetective.ViewModels
{
    public class ProfileViewModel
    {
        [Key]
        public int ProfileId { get; set; }
        [Required]
        public string ProfileName { get; set; }
        public int SessionId { get; set; }

        public ProfileViewModel() { }
    }
}