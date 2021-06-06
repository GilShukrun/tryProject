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
        public string Name { get; set; }

        [Required(ErrorMessage ="You must insert the amount of money you want to donate")]
        public int Sum{ get; set; }
        [Display(Name = "Raised so far")]
        public int RaisedSoFar { get; set; }

        [Required(ErrorMessage = "You must say which purpose this money is donate for")]
        [Display(Name = "Purpose")]
        public int PurposeId { get; set; }
        public Purpose Purpose { get; set; }

        public Association Association { get; set; }
        [Display(Name = "Association")]
        public int AssociationId { get; set; }
        
    }
}
