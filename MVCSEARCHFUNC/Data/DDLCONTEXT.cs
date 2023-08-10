using MVCSEARCHFUNC.Models.DDL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCSEARCHFUNC.Data
{
    public class DDLCONTEXT:DbContext
    {
        public DDLCONTEXT() : base("MyConnectionString")
        {

        }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
    }
}