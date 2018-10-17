using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class DbContextTest : DbContext
    {
        public DbContextTest(DbContextOptions<DbContextTest> options)
            : base(options)
        {
        }

        #region 重载
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.AddConfiguration(new ApplicationConfiguration());
        }
        #endregion
    }

    internal class ApplicationConfiguration : DbEntityConfiguration<ApplicationEntity>
    {
        public override void Configure(EntityTypeBuilder<ApplicationEntity> entity)
        {
            entity.ToTable("application");

            entity.HasIndex(e => e.Token)
                .HasName("unique_application_token")
                .IsUnique();

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            entity.Property(e => e.IsDelete)
                .HasColumnName("is_delete")
                .HasColumnType("tinyint(1)");

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(255)");

            entity.Property(e => e.Token)
                .HasColumnName("token")
                .HasColumnType("varchar(32)");
        }
    }


    internal static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(
          this ModelBuilder modelBuilder,
          DbEntityConfiguration<TEntity> entityConfiguration) where TEntity : class
        {
            modelBuilder.Entity<TEntity>(entityConfiguration.Configure);
        }
    }

    internal abstract class DbEntityConfiguration<TEntity> where TEntity : class
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> entity);
    }
}
