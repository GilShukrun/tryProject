using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class Manager
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="You must write the name of the manager")]
        public string Name { get; set; }

        [Display(Name = "Association Name")]
        [Required(ErrorMessage = "You must write which association he manages")]
        public int AssociationId { get; set; }
        
        public Association Association { get; set; }
    }
}
