using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GenericLoginFramework
{
    public class GLFDbContext : DbContext
    {
        #region Properties
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        #endregion

        #region Methods
        public GLFDbContext(string name, bool isConnName) : base(isConnName ? String.Format("name={0}", name) : name)
        {
            Database.CreateIfNotExists();
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(entity => entity.ToTable(String.Format("glf.{0}"), entity.ClrType.Name));
            modelBuilder.Entity<User>().HasOptional(user => user.Resources);
            modelBuilder.Entity<Resource>().HasRequired(resource => resource.User);
        }
        #endregion
    }
}
