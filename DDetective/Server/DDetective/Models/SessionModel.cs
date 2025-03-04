using Microsoft.Build.Framework.Profiler;
using System;
using System.ComponentModel.DataAnnotations;
using DDetctive.Models;

namespace DDetective.Models
{
    public class SessionModel
    {
        [Key]
        public int SessionId { get; set; } // Primary Key Property
        public string SessionName { get; set; }
        public string SessionToken { get; set; }
        public DateTime ExpirationDate { get; set; }

        // Session can have multiple Profiles
        public ICollection<Profile> Profiles { get; } = new List<Profile>();

        public SessionModel() { }

        public SessionModel(int sessionId, string sessionName, string sessionToken, DateTime expirationDate)
        {
            SessionId = sessionId;
            SessionName = sessionName;
            SessionToken = sessionToken;
            ExpirationDate = expirationDate;
        }


    }


}