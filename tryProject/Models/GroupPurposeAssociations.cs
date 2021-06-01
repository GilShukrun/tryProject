using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class GroupPurposeAssociations
    {
        public string GroupName { get; set; }

        public IEnumerable<Association> items { get; set; }
    }
}
