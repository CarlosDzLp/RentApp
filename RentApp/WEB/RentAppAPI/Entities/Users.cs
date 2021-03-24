using System;
using System.ComponentModel.DataAnnotations;

namespace RentAppAPI.Entities
{
    public class Users
    {
        [Key]
        public Guid IdUser { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Image { get; set; }


        public DateTime DateCreated { get; set; }


        public bool IsRent { get; set; }


        public bool IsActive { get; set; }
    }
}
