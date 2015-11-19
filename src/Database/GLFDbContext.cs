using GenericLoginFramework.OAuth.Resources;
using GenericLoginFramework.OpenID.Resources;
using System.Data.Entity;

namespace GenericLoginFramework.Database
{
    class GLFDbContext : DbContext
    {
        public GLFDbContext(string name, bool isConnName)
            : base(isConnName ? string.Format("name={0}", name) : name)
        {
            Database.CreateIfNotExists();
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<FacebookResource> FacebookResources { get; set; }
        public virtual DbSet<GoogleResource> GoogleResources { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(entity => entity.ToTable("glf." + entity.ClrType.Name));
        }
    }
}
