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



        public DbSet<tryProject.Models.Association> Association { get; set; }




        public DbSet<tryProject.Models.CommunityWorks> CommunityWorks { get; set; }



        public DbSet<tryProject.Models.Purpose> Purpose { get; set; }



        public DbSet<tryProject.Models.Manager> Manager { get; set; }



        public DbSet<tryProject.Models.User> User { get; set; }



        public DbSet<tryProject.Models.CatersTo> CatersTo { get; set; }



        public DbSet<tryProject.Models.WorkOrGive> WorkOrGive { get; set; }



        public DbSet<tryProject.Models.Zone> Zone { get; set; }

    }
}
