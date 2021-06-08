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
        [Required(ErrorMessage ="You must describe this work")]
        public string Decscription { get; set; }

        public Association Association { get; set; }
        public int AssociationId { get; set; }

        public WorkOrGive WorkOrGive { get; set; }
        public int WorkOrGiveId { get; set; }
    }
}
