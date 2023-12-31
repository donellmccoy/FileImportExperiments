﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using FileImportExperiments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models.Configurations
{
    public partial class TaskDetailConfiguration : IEntityTypeConfiguration<TaskDetail>
    {
        public void Configure(EntityTypeBuilder<TaskDetail> entity)
        {
            entity.ToTable("TASK_DETAIL", "DCW");

            entity.Property(e => e.TaskDetailId).HasColumnName("TASK_DETAIL_ID");
            entity.Property(e => e.DeleteAfterDate)
            .HasColumnType("datetime")
            .HasColumnName("DELETE_AFTER_DATE");
            entity.Property(e => e.LegalDescription)
            .HasMaxLength(1000)
            .IsUnicode(false)
            .HasColumnName("LEGAL_DESCRIPTION");
            entity.Property(e => e.SecondaryReference)
            .HasMaxLength(20)
            .IsUnicode(false)
            .HasColumnName("SECONDARY_REFERENCE");
            entity.Property(e => e.TaskId).HasColumnName("TASK_ID");
            entity.Property(e => e.TypeOfInstrument)
            .HasMaxLength(10)
            .IsUnicode(false)
            .HasColumnName("TYPE_OF_INSTRUMENT");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskDetail)
            .HasForeignKey(d => d.TaskId)
            .HasConstraintName("FK_TASK_TASK_DETAIL");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<TaskDetail> entity);
    }
}
