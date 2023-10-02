﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using FileImportExperiments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models.Configurations
{
    public partial class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> entity)
        {
            entity.HasKey(e => e.TaskId).HasName("PK_TASK2");

            entity.ToTable("TASK", "DCW");

            entity.Property(e => e.TaskId).HasColumnName("TASK_ID");
            entity.Property(e => e.Assigned)
            .HasDefaultValueSql("((0))")
            .HasColumnName("ASSIGNED");
            entity.Property(e => e.Complete)
            .HasDefaultValueSql("((0))")
            .HasColumnName("COMPLETE");
            entity.Property(e => e.CompletedBy)
            .HasMaxLength(30)
            .IsUnicode(false)
            .HasColumnName("COMPLETED_BY");
            entity.Property(e => e.EventId).HasColumnName("EVENT_ID");
            entity.Property(e => e.TaskTypeCode)
            .IsRequired()
            .HasMaxLength(10)
            .IsUnicode(false)
            .HasColumnName("TASK_TYPE_CODE");
            entity.Property(e => e.Verified).HasColumnName("VERIFIED");
            entity.Property(e => e.VerifiedSource)
            .HasMaxLength(260)
            .IsUnicode(false)
            .HasColumnName("VERIFIED_SOURCE");

            entity.HasOne(d => d.CompletedByNavigation).WithMany(p => p.Task)
            .HasForeignKey(d => d.CompletedBy)
            .HasConstraintName("FK_TASK_COMPLETEDBY");

            entity.HasOne(d => d.Event).WithMany(p => p.Task)
            .HasForeignKey(d => d.EventId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_EVENT_TASK");

            entity.HasOne(d => d.TaskTypeCodeNavigation).WithMany(p => p.Task)
            .HasForeignKey(d => d.TaskTypeCode)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_TASK_TYPE_TASK");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Task> entity);
    }
}