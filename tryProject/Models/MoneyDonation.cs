using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class MoneyDonation
    {
        public  int Id { get; set; }
        public int Sum{ get; set; }

        public int PurposeId { get; set; }
        public Purpose Purpose { get; set; }
        
    }
}
