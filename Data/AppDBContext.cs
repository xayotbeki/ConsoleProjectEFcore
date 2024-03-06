using Microsoft.EntityFrameworkCore;
using royhat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace royhat.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Royhat> royhats {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = "Server = (localdb)\\MSSQLLocalDB;" +
                "Database = Royhat;" +
                "Trusted_Connection = True;";
            optionsBuilder.UseSqlServer(path);
        }
    }
}
