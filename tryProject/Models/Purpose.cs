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
        public string Name { get; set; }

        public List<MoneyDonation> MoneyDonation{ get; set; }

        [Display(Name="Association")]
        public List<Association> Association { get; set; }
    }
}
