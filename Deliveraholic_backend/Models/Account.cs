using System;
using System.ComponentModel.DataAnnotations;

namespace deliveraholic_backend.Models
{
    public enum AccountType
    {
        user = 0,
        deliverer = 1
    }

    public class Account
    {
        [Required]
        public Guid accountID { get; set; }

        [MaxLength(75)]
        [MinLength(2)]
        [Required]
        public string firstName { get; set; }

        [MaxLength(75)]
        [MinLength(2)]
        [Required]
        public string lastName { get; set; }

        [EmailAddress]
        [MaxLength(320)]
        [Required]
        public string email { get; set; }

        [Phone]
        [Required]
        public string phoneNumber { get; set; }

        public AccountType type { get; set; }

        public string passwordHash { get; set; }

        public string passwordSalt { get; set; }

        public DateTime createdAt { get; set; }
    }
}