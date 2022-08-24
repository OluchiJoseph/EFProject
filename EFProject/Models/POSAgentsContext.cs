using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFProject.Models
{
    public partial class POSAgentsContext : DbContext
    {
        public POSAgentsContext()
        {
        }

        public POSAgentsContext(DbContextOptions<POSAgentsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgentProfile> AgentProfiles { get; set; } = null!;
        public virtual DbSet<CustomerProfile> CustomerProfiles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER01;Database= POSAgents;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgentProfile>(entity =>
            {
                entity.HasKey(e => e.AgentId);

                entity.ToTable("Agent_Profile");

                entity.Property(e => e.AgentId).HasColumnName("Agent_Id");

                entity.Property(e => e.AgentName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Agent_Name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Number");

                entity.Property(e => e.WorkingArea)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Working_Area");
            });

            modelBuilder.Entity<CustomerProfile>(entity =>
            {
                entity.ToTable("Customer_Profile");

                entity.Property(e => e.AgentId).HasColumnName("Agent_Id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Number");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
