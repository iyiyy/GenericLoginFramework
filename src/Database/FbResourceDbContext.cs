using System;
using System.Data.Entity;

namespace GenericLoginFramework.Database
{
    class FbResourceDbContext : DbContext
    {
        public FbResourceDbContext() : base()
        {
            Database.Initialize(true);
        }

        public FbResourceDbContext(string name, bool connStringName)
            : base(connStringName ? String.Format("name={0}", name) : name)
        {
            Database.Initialize(true);
        }

        public DbSet<FacebookResource> FacebookResources { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(entity => entity.ToTable("glf." + entity.ClrType.Name);
        }
    }
}
