using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Test.Models;

namespace Test.Models
{
    public class BaseContext : DbContext
    {
        public DbSet<Pasta> Pastas { get; set; }
    }
}