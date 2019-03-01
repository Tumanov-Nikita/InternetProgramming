using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeBudget.Models;

namespace WeBudget
{
    public class DoskaContext : DbContext
    {
        public DbSet <User> Users { get; set; }
        public DbSet<Notice> Notices { get; set; }
    }
}