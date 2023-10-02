﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models;

public partial class PostingAttempt
{
    public long PostingAttemptId { get; set; }

    public long DocumentDescriptionId { get; set; }

    public string CorrelationId { get; set; }

    public byte PostingAttemptStatusId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public virtual DocumentDescription DocumentDescription { get; set; }

    public virtual PostingAttemptStatus PostingAttemptStatus { get; set; }

    public virtual ICollection<PostingResult> PostingResult { get; set; } = new List<PostingResult>();
}