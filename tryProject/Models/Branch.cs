using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class Branch
    {
        public  int Id  { get; set; }

        public string Name { get; set; }

        public int AssociationId { get; set; }
        public Association Association   { get; set; }

    }
}
