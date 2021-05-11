using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class Purpose
    {

        public  int Id { get; set; }
        [Required(ErrorMessage ="You must say the purpose of this donation")]
        public string Name { get; set; }

        public List<MoneyDonation> MoneyDonation{ get; set; }

        [Display(Name="Association")]
        [Required(ErrorMessage ="You must say which associations work for this purpose")]
        public List<Association> Association { get; set; }
    }
}
