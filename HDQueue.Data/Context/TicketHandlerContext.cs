﻿using HDQueue.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDQueue.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() :
            base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Cierre> Cierres { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>()
                .HasOptional(t => t.Cierre)
                .WithRequired(c => c.Ticket);
        }

    }
}