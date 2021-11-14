using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Domain
{
    public partial class ConfContext : DbContext
    {
        public ConfContext()
        {

        }

        public ConfContext(DbContextOptions<ConfContext> options) : base(options)
        {

        }

        public virtual DbSet<Speaker> Speakers { get; set; }
        public virtual DbSet<Talk> Talks { get; set; }
        public virtual DbSet<Workshop> Workshops { get; set; }
       

    }
}
