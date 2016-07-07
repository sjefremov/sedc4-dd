using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SciFiContext : DbContext
    {
        public SciFiContext() : base("SciFiDatabase")
        {
            Database.SetInitializer<SciFiContext>(null);//disable migrations
        }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorMap());

            

            //modelBuilder
            //    .Entity<Author>()
            //    .HasKey(author => author.ID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
