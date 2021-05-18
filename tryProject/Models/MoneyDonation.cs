using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class MoneyDonation
    {
        public  int Id { get; set; }

        [Required(ErrorMessage ="You must insert the amount of money you want to donate")]
        public int Sum{ get; set; }

        [Required(ErrorMessage = "You must say which purpose this money is donate for")]
        [Display(Name = "Purpose")]
        public int PurposeId { get; set; }
        
        public Purpose Purpose { get; set; }
        
    }
}
