using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class Association
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="You must write the name of the association")]
        public string Name { get; set; }

        [StringLength(50,MinimumLength =5)]
        [Required(ErrorMessage ="You must write the city of this association")]
        public string  City { get; set; }

        [Required]
        public List<Purpose> Purposes { get; set; }

        public List<CommunityWorks> CommunityWorks{ get; set; }
      

        [Required(ErrorMessage ="You must write the manger of this association")]
        public Manager Manager { get; set; }
    }
}
