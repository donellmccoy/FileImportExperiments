﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using FileImportExperiments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models.Configurations
{
    public partial class BatchConfiguration : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> entity)
        {
            entity.ToTable("BATCH");

            entity.Property(e => e.BatchId).HasColumnName("BATCH_ID");
            entity.Property(e => e.BatchStatusId).HasColumnName("BATCH_STATUS_ID");
            entity.Property(e => e.CountyId).HasColumnName("COUNTY_ID");
            entity.Property(e => e.CreateDate)
            .HasColumnType("datetime")
            .HasColumnName("CREATE_DATE");
            entity.Property(e => e.Notes)
            .IsRequired()
            .IsUnicode(false)
            .HasColumnName("NOTES");
            entity.Property(e => e.Reference)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("REFERENCE");
            entity.Property(e => e.UpdateDate)
            .HasColumnType("datetime")
            .HasColumnName("UPDATE_DATE");

            entity.HasOne(d => d.BatchStatus).WithMany(p => p.Batch)
            .HasForeignKey(d => d.BatchStatusId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BATCH_BATCH_STATUS");

            entity.HasOne(d => d.County).WithMany(p => p.Batch)
            .HasForeignKey(d => d.CountyId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BATCH_COUNTY");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Batch> entity);
    }
}