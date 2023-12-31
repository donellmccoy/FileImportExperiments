﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using FileImportExperiments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models.Configurations
{
    public partial class OnDemandReportPathConfiguration : IEntityTypeConfiguration<OnDemandReportPath>
    {
        public void Configure(EntityTypeBuilder<OnDemandReportPath> entity)
        {
            entity.ToTable("ON_DEMAND_REPORT_PATH");

            entity.Property(e => e.OnDemandReportPathId).HasColumnName("ON_DEMAND_REPORT_PATH_ID");
            entity.Property(e => e.CreateDate)
            .HasColumnType("datetime")
            .HasColumnName("CREATE_DATE");
            entity.Property(e => e.DataCenterId).HasColumnName("DATA_CENTER_ID");
            entity.Property(e => e.OnDemandReportId).HasColumnName("ON_DEMAND_REPORT_ID");
            entity.Property(e => e.OnDemandReportPath1)
            .IsRequired()
            .HasMaxLength(1000)
            .IsUnicode(false)
            .HasColumnName("ON_DEMAND_REPORT_PATH");
            entity.Property(e => e.UpdateDate)
            .HasColumnType("datetime")
            .HasColumnName("UPDATE_DATE");

            entity.HasOne(d => d.DataCenter).WithMany(p => p.OnDemandReportPath)
            .HasForeignKey(d => d.DataCenterId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ON_DEMAND_REPORT_PATH_DATA_CENTER");

            entity.HasOne(d => d.OnDemandReport).WithMany(p => p.OnDemandReportPath)
            .HasForeignKey(d => d.OnDemandReportId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ON_DEMAND_REPORT_PATH_ON_DEMAND_REPORT");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<OnDemandReportPath> entity);
    }
}
