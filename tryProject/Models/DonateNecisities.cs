using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class DonateNecisities
    {
        public int Id { get; set; }

        public string Area { get; set; }

        [Display(Name="You want to donate to:")]
        public string whoIsFor { get; set; }
    }
}
