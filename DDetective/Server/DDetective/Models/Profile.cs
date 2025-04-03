using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DDetctive.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }
        public int SessionId { get; set; }

        public Profile() { }

        public Profile(int profileId, string profileName, int sessionId)
        { 
            ProfileId = profileId;
            ProfileName = profileName;
            SessionId = sessionId;
        }
    }
}
