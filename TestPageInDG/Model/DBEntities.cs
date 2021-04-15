using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TestPageInDG.Model
{
    public partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=DBEntities")
        {
        }

        public virtual DbSet<AssetGroup> AssetGroups { get; set; }
        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<ChangedPart> ChangedParts { get; set; }
        public virtual DbSet<DepartmentLocation> DepartmentLocations { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<EmergencyMaintenance> EmergencyMaintenances { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetGroup>()
                .HasMany(e => e.Assets)
                .WithRequired(e => e.AssetGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Asset>()
                .HasMany(e => e.EmergencyMaintenances)
                .WithRequired(e => e.Asset)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DepartmentLocation>()
                .HasMany(e => e.Assets)
                .WithRequired(e => e.DepartmentLocation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.DepartmentLocations)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmergencyMaintenance>()
                .HasMany(e => e.ChangedParts)
                .WithRequired(e => e.EmergencyMaintenance)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Assets)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.DepartmentLocations)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Part>()
                .HasMany(e => e.ChangedParts)
                .WithRequired(e => e.Part)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Priority>()
                .HasMany(e => e.EmergencyMaintenances)
                .WithRequired(e => e.Priority)
                .WillCascadeOnDelete(false);
        }
    }
}
