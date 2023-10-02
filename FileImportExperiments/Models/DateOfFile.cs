﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models;

public partial class DateOfFile
{
    public long DateOfFileId { get; set; }

    public byte CountyId { get; set; }

    public DateTime Date { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public bool? IsCertified { get; set; }

    public bool? IsDataCenterSuccessful { get; set; }

    public bool? IsOverallSuccessful { get; set; }

    public virtual County County { get; set; }

    public virtual ICollection<Event> Event { get; set; } = new List<Event>();

    public virtual ICollection<ImageBatch> ImageBatch { get; set; } = new List<ImageBatch>();
}