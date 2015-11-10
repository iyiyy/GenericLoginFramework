namespace GenericLoginFramework.Database
{
    using System.Data.Entity;

    class UserDbContext : DbContext
    {
        public UserDbContext() : base()
        {
            Database.Initialize(true);
        }

        public UserDbContext(string name, bool isConnStringName)
            : base(isConnStringName ? string.Format("name={0}", name) : name)
        {
            Database.Initialize(true);
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(entity => entity.ToTable("glf." + entity.ClrType.Name));
        }
    }
}
