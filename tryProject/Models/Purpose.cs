using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class Purpose
    {

        public  int Id { get; set; }

        public string Name { get; set; }

        public List<MoneyDonation> MoneyDonation{ get; set; }

        public List<Association> AssociationId { get; set; }
    }
}
