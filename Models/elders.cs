using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace village.Models
{
    public class elders
    {


        public partial class Village : DbContext
        {
            public Village()
                : base("name=Village")
            {

            }

            public virtual DbSet<Citizen> Citizen { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {

            }
        }
    }
}