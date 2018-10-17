using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBFirstTest
{
    public partial class dit_prod_logContext : DbContext
    {
        public dit_prod_logContext()
        {
        }

        public dit_prod_logContext(DbContextOptions<dit_prod_logContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<LogException> LogException { get; set; }
        public virtual DbSet<LogRequest> LogRequest { get; set; }
        public virtual DbSet<LogResponse> LogResponse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=192.168.199.52;User Id=dit_prod_log;Password=123456;Database=dit_prod_log");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>(entity =>
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
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log");

                entity.HasIndex(e => e.ApplicationId)
                    .HasName("fk_log_application");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApplicationId)
                    .HasColumnName("application_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApplicationName)
                    .HasColumnName("application_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Browser)
                    .HasColumnName("browser")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ExecuteMilliseconds)
                    .HasColumnName("execute_milliseconds")
                    .HasColumnType("double(11,3)");

                entity.Property(e => e.GmtCreate)
                    .HasColumnName("gmt_create")
                    .HasColumnType("datetime");

                entity.Property(e => e.Host)
                    .HasColumnName("host")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.HttpMethod)
                    .HasColumnName("http_method")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.IsUntreatedException)
                    .HasColumnName("is_untreated_exception")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.RequestTime)
                    .HasColumnName("request_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResponseTime)
                    .HasColumnName("response_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(2000)");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Log)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("fk_log_application");
            });

            modelBuilder.Entity<LogException>(entity =>
            {
                entity.ToTable("log_exception");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ExceptionMessage)
                    .HasColumnName("exception_message")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.LogException)
                    .HasForeignKey<LogException>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_log_exception_log");
            });

            modelBuilder.Entity<LogRequest>(entity =>
            {
                entity.ToTable("log_request");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RequestBody)
                    .HasColumnName("request_body")
                    .HasColumnType("text");

                entity.Property(e => e.RequestHeaders)
                    .HasColumnName("request_headers")
                    .HasColumnType("varchar(4000)");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.LogRequest)
                    .HasForeignKey<LogRequest>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_log_request_log");
            });

            modelBuilder.Entity<LogResponse>(entity =>
            {
                entity.ToTable("log_response");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ResponseBody)
                    .HasColumnName("response_body")
                    .HasColumnType("text");

                entity.Property(e => e.ResponseHeaders)
                    .HasColumnName("response_headers")
                    .HasColumnType("varchar(4000)");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.LogResponse)
                    .HasForeignKey<LogResponse>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_log_response_log");
            });
        }
    }
}
