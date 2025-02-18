using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace theDeadlines.DAL.Models;

public class DeadlinesContext : DbContext
{
    public DeadlinesContext(DbContextOptions<DeadlinesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Checklist> Checklists { get; set; }

    public virtual DbSet<ChecklistItem> ChecklistItems { get; set; }

    public virtual DbSet<Deadline> Deadlines { get; set; }

    public virtual DbSet<SubDeadline> SubDeadlines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Checklist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Checklis__3213E83F7436A59C");

            entity.HasOne(d => d.SubDeadline).WithMany(p => p.Checklists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checklist__sub_d__3C69FB99");
        });

        modelBuilder.Entity<ChecklistItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Checklis__3213E83F2AFA52A5");

            entity.HasOne(d => d.Checklist).WithMany(p => p.ChecklistItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checklist__check__403A8C7D");
        });

        modelBuilder.Entity<Deadline>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Deadline__3213E83F60841816");
        });

        modelBuilder.Entity<SubDeadline>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubDeadl__3213E83F351D4B4C");

            entity.HasOne(d => d.Deadline).WithMany(p => p.SubDeadlines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubDeadli__deadl__398D8EEE");
        });
    }
}