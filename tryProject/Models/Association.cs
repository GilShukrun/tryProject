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
        [StringLength(50, MinimumLength = 5)]
        public string Website { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string Email { get; set; }
        
        public List<Purpose> Purposes { get; set; }

        public List<CommunityWorks> CommunityWorks{ get; set; }

        public Manager Manager { get; set; }

        public List<Zone> Zones { get; set; }
        public List<CatersTo> CatersTo { get; set; }
    }
}
