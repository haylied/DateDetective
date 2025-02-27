using System;
using System.ComponentModel.DataAnnotations;

namespace DDetective.Models
{
    public class SessionModel
    {
        [Key]
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public string SessionToken { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}