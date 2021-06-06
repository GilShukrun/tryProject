using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class CatersTo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Association> Associations { get; set; }
    }
}
