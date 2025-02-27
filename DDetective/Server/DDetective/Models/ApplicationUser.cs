using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DDetective.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailConfirmed { get; set; }
        public DateTime AccountCreationDate { get; set; } = DateTime.Now;

        public ApplicationUser()
        {

        }

        public ApplicationUser(int userId, string firstName, string lastName, string emailConfirmed, DateTime accountCreationDate)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            EmailConfirmed = emailConfirmed;
            AccountCreationDate = accountCreationDate;


        }
    }
}