﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using FileImportExperiments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models.Configurations
{
    public partial class CngapResultsConfiguration : IEntityTypeConfiguration<CngapResults>
    {
        public void Configure(EntityTypeBuilder<CngapResults> entity)
        {
            entity
            .HasNoKey()
            .ToTable("CNGapResults", "CDC");

            entity.Property(e => e.ClerkNumberGapFromCn).HasColumnName("ClerkNumberGapFromCN");
            entity.Property(e => e.ClerkNumberGapToCn).HasColumnName("ClerkNumberGapToCN");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<CngapResults> entity);
    }
}