using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class CommunityWorks
    {
        public int Id { get; set; }

        public string Decscription { get; set; }

        public List<Association> Association { get; set; }
    }
}
