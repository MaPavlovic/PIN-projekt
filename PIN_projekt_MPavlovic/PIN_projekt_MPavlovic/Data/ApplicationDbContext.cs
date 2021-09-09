using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PIN_projekt_MPavlovic.Models;

namespace PIN_projekt_MPavlovic.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PIN_projekt_MPavlovic.Models.Proizvodi> Proizvodi { get; set; }
        public DbSet<PIN_projekt_MPavlovic.Models.Zapo> Zapo { get; set; }
    }
}
