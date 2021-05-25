using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public string Id { get; set; }
        [StringLength (200 , MinimumLength = 6)]
        [Required(ErrorMessage = "You must enter a User Name")]
        [Display(Name = "User Name")]
    
        public string UserName { get; set; }

        [StringLength(200, MinimumLength = 6)]
        [Required (ErrorMessage = " You must enter a Password" ) ]

        [DataType(DataType.Password)]
        

        public string Password { get; set; }

        public UserType Type { get; set; } = UserType.Donates;

        public Boolean Volunteer { get; set; }
        
        [RegularExpression ("^[A-Z]+[a-zA-Z ]",ErrorMessage = " You can use only letters")]
         public string Name { get; set; }

        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
