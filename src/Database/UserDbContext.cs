using System;
using System.Data.Entity;

namespace GenericLoginFramework.Database
{
    class UserDbContext : DbContext
    {
        public UserDbContext() : base()
        {
            Database.Initialize(true);
        }

        public UserDbContext(string name, bool connStringName)
            : base(connStringName ? String.Format("name={0}", name) : name)
        {
            Database.Initialize(true);
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(entity => entity.ToTable("glf." + entity.ClrType.Name);
        }
    }
}
