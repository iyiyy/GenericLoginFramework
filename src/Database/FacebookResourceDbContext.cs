using System;
using System.Data.Entity;

using GenericLoginFramework.OAuth.Resources;

namespace GenericLoginFramework.Database
{
    class FacebookResourceDbContext : DbContext
    {
        public FacebookResourceDbContext() : base()
        {
            Database.Initialize(true);
        }

        public FacebookResourceDbContext(string name, bool isConnName)
            : base(isConnName ? String.Format("name={0}", name) : name)
        {
            Database.Initialize(true);
        }

        public DbSet<FacebookResource> FacebookResources { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(entity => entity.ToTable("glf." + entity.ClrType.Name));
        }
    }
}
