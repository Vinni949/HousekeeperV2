using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace HousekeeperV2.Models
{
    internal class DBHousekeeper: DbContext
    {
        public DBHousekeeper()
        {
        }
        public DBHousekeeper(DbContextOptions<DBHousekeeper> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Key> Keys { get;set; }
        public DbSet<Teacher> Teachers { get;set; }
        public DbSet<histories> histories { get;set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=HousekeeperV2.db");
        }
    }
}
