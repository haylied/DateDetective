using System;
using System.ComponentModel.DataAnnotations;

namespace DDetective.Models
{
    public class Session
    {
        [Key]
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public string SessionToken { get; set; }
        public DateTime ExpirationTime { get; set; }

        public Session() { }

        public Session(int sessionId, string sessionName, string sessionToken, DateTime expirationTime)
        {
            SessionId = sessionId;
            SessionName = sessionName;
            SessionToken = sessionToken;
            ExpirationTime = expirationTime;


    }


}