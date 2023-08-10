using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCSEARCHFUNC.Models
{
    public class APPDBCONTEXT:DbContext
    {
        public APPDBCONTEXT() : base("MyConnectionString")
        {
            
        }
        public DbSet<Record> Record { get; set; }
    }
}
