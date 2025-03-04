using System;
using System.ComponentModel;
using Systm.ComponentModel.DataAnnotations;
using DDetctive.Models;

namespace DDetctive.Models
{
    public class Profile
    {
        public int ProfileId { get; set; } // Primary Key Property
        public string ProfileName { get; set; }
        public int SessionId { get; set; } // Foreign Key Property

        // if one-to-many
        public Session Session { get; set; } // = null!; -- should this be non-nullable?

        // if one-to-one

        public Profile() { }

        public Profile(int profileId, string profileName, int sessionId)
        { 
            ProfileId = profileId;
            ProfileName = profileName;
            SessionId = sessionId;
        }
    }
}
