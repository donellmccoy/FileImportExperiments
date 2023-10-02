﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using FileImportExperiments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models.Configurations
{
    public partial class UnchainedLegalDescriptionConfiguration : IEntityTypeConfiguration<UnchainedLegalDescription>
    {
        public void Configure(EntityTypeBuilder<UnchainedLegalDescription> entity)
        {
            entity.ToTable("UNCHAINED_LEGAL_DESCRIPTION", "DCW");

            entity.Property(e => e.UnchainedLegalDescriptionId).HasColumnName("UNCHAINED_LEGAL_DESCRIPTION_ID");
            entity.Property(e => e.UnchainedLegalDescription1)
            .HasMaxLength(1000)
            .IsUnicode(false)
            .HasColumnName("UNCHAINED_LEGAL_DESCRIPTION");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<UnchainedLegalDescription> entity);
    }
}
