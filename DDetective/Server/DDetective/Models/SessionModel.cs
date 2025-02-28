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