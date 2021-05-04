using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tryProject.Models;

namespace tryProject.Data
{
    public class tryProjectContext : DbContext
    {
        public tryProjectContext (DbContextOptions<tryProjectContext> options)
            : base(options)
        {
        }

        public DbSet<tryProject.Models.MoneyDonation> MoneyDonation { get; set; }

        public DbSet<tryProject.Models.DonateNecisities> DonateNecisities { get; set; }

        public DbSet<tryProject.Models.Association> Association { get; set; }
    }
}
