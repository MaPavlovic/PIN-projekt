using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PIN_projekt_MPavlovic.Models
{
    public class Zaposlenici:DbContext
    {
        public Zaposlenici(DbContextOptions<Zaposlenici>options):base(options)
        {

        }
        public DbSet<Zapo> Zaposlenik { get; set; }
    }
}
