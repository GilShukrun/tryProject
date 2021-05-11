using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class Association
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string  City { get; set; }

        public List<Purpose> Purposes { get; set; }

        public List<CommunityWorks> CommunityWorks{ get; set; }

        public Manager Manager { get; set; }
    }
}
