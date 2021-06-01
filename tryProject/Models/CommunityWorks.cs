using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class CommunityWorks
    {
        public int Id { get; set; }

        [StringLength(200, MinimumLength =10)]
        [RegularExpression("^[A-Z]+[a-z A-z]")]
        [Required(ErrorMessage ="You must describe this work")]
        public string Decscription { get; set; }

        [Required(ErrorMessage ="You must write the association that do this work")]
        public List<Association> Association { get; set; }
    }
}
