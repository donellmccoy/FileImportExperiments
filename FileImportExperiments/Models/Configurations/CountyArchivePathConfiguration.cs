﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using FileImportExperiments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models.Configurations
{
    public partial class CountyArchivePathConfiguration : IEntityTypeConfiguration<CountyArchivePath>
    {
        public void Configure(EntityTypeBuilder<CountyArchivePath> entity)
        {
            entity.ToTable("COUNTY_ARCHIVE_PATH");

            entity.Property(e => e.CountyArchivePathId).HasColumnName("COUNTY_ARCHIVE_PATH_ID");
            entity.Property(e => e.CountyId).HasColumnName("COUNTY_ID");
            entity.Property(e => e.CreateDate)
            .HasColumnType("datetime")
            .HasColumnName("CREATE_DATE");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.Path)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasColumnName("PATH");
            entity.Property(e => e.UpdateDate)
            .HasColumnType("datetime")
            .HasColumnName("UPDATE_DATE");

            entity.HasOne(d => d.County).WithMany(p => p.CountyArchivePath)
            .HasForeignKey(d => d.CountyId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_COUNTY_ARCHIVE_PATH_COUNTY");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<CountyArchivePath> entity);
    }
}