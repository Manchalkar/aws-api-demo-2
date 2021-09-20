using Etools.Entities.EntityModels;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etools.Entities.DbContexts
{
    public class EtoolsDbContext : DbContext
    {
        public EtoolsDbContext()
        {

        }
        public EtoolsDbContext(DbContextOptions<EtoolsDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Demo>(entity =>

            {

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");



                entity.Property(e => e.IsActive)

                    .IsRequired()

                    .HasDefaultValueSql("((1))");



                entity.Property(e => e.LastUpdated)

                    .HasColumnType("datetime")

                    .HasDefaultValueSql("(getdate())");

            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\LocalDBDemo;Database=eTools;Trusted_Connection=True;MultipleActiveResultSets=true",b => b.MigrationsAssembly("Etools.WebApi"));
            }
        }
        public DbSet<Temp> Temp { get; set; }
        public DbSet<Demo> Demo { get; set; }
    }
}
