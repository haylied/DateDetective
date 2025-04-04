using System;
using DDetective.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DDetctive.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }
        public List<Session> Sessions { get; set; } = new();

        public Profile() { }

        public Profile(int profileId, string profileName)
        { 
            ProfileId = profileId;
            ProfileName = profileName;
        }
    }
}
