namespace WebApplication2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DefaultConnections")
        {
        }

        public virtual DbSet<Table1> Table1 { get; set; }
        public virtual DbSet<Table2> Table2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table1>()
                .Property(e => e.Songs)
                .IsFixedLength();

            modelBuilder.Entity<Table1>()
                .Property(e => e.Album)
                .IsFixedLength();

            modelBuilder.Entity<Table1>()
                .Property(e => e.Movie)
                .IsFixedLength();

            modelBuilder.Entity<Table1>()
                .HasMany(e => e.Table2)
                .WithRequired(e => e.Table1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Table2>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<Table2>()
                .Property(e => e.Awards)
                .IsFixedLength();
        }
    }
}
