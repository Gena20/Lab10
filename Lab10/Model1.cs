namespace Lab10
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<car> cars { get; set; }
        public virtual DbSet<_object> objects { get; set; }
        public virtual DbSet<trip> trips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<car>()
                .HasMany(e => e.trips)
                .WithRequired(e => e.car)
                .HasForeignKey(e => e.car_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<_object>()
                .HasMany(e => e.trips)
                .WithRequired(e => e._object)
                .HasForeignKey(e => e.object_form_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<_object>()
                .HasMany(e => e.trips1)
                .WithRequired(e => e.object1)
                .HasForeignKey(e => e.object_to_id)
                .WillCascadeOnDelete(false);
        }
    }
}
