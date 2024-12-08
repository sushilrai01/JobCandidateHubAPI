using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHubAPI.Entity;

public partial class JobCandidateHubDbContext : DbContext
{
    public JobCandidateHubDbContext()
    {
    }

    public JobCandidateHubDbContext(DbContextOptions<JobCandidateHubDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCandidate> TblCandidates { get; set; }  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCandidate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CandidateTable");

            entity.ToTable("tbl_Candidate");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CallTimeInterval)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Comment).IsUnicode(false);
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GithubUrl)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LinkedInUrl)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
