using System;
using System.Data.Entity;

using GenericLoginFramework.OpenID.Resources;

namespace GenericLoginFramework.Database
{
    class GoogleResourceDbContext : DbContext
    {
        public GoogleResourceDbContext() : base()
        {
            Database.Initialize(true);
        }

        public GoogleResourceDbContext(string name, bool isConnName)
            : base(isConnName ? String.Format("name={0}", name) : name)
        {
            Database.Initialize(true);
        }

        public DbSet<GoogleResource> GoogleResources { get; set}
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(entity => entity.ToTable("glf." + entity.ClrType.Name));
        }
    }
}
