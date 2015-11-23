using GenericLoginFramework.OAuth.Resources;
using GenericLoginFramework.OpenID.Resources;
using System.Data.Entity;
using System.Reflection;

namespace GenericLoginFramework.Database
{
    partial class GLFDbContext : DbContext
    {
        public GLFDbContext(string name, bool isConnName) : base(isConnName ? string.Format("name={0}", name) : name)
        {
            Database.CreateIfNotExists();
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<FacebookResource> FacebookResources { get; set; }
        public virtual DbSet<GoogleResource> GoogleResources { get; set; }
        public virtual DbSet<User> Users { get; set; }

        partial void ModelCreating(DbModelBuilder modelBuilder);

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(entity => entity.ToTable("glf." + entity.ClrType.Name));
            modelBuilder.Entity<User>().HasOptional(u => u.FacebookResource);
            modelBuilder.Entity<User>().HasOptional(u => u.GoogleResource);
            modelBuilder.Entity<FacebookResource>().HasRequired(r => r.User);
            modelBuilder.Entity<GoogleResource>().HasRequired(r => r.User);

            ModelCreating(modelBuilder);
        }

    }
}
