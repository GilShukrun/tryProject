using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public enum UserType
    {
        Donates,
        Volunteer,
        Admin,
    }
    public class User
    {

        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public UserType Type { get; set; } = UserType.Donates;

        public Boolean Volunteer { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }


    }
}
