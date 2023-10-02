﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using FileImportExperiments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models.Configurations
{
    public partial class GetNewWorkLockConfiguration : IEntityTypeConfiguration<GetNewWorkLock>
    {
        public void Configure(EntityTypeBuilder<GetNewWorkLock> entity)
        {
            entity.HasKey(e => new { e.Username, e.StartTime });

            entity.ToTable("GET_NEW_WORK_LOCK", "DCW");

            entity.Property(e => e.Username)
            .HasMaxLength(30)
            .IsUnicode(false)
            .HasColumnName("USERNAME");
            entity.Property(e => e.StartTime)
            .HasColumnType("datetime")
            .HasColumnName("START_TIME");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<GetNewWorkLock> entity);
    }
}
