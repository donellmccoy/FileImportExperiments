﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models;

public partial class PostingResult
{
    public long PostingResultId { get; set; }

    public long PostingAttemptId { get; set; }

    public string Status { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public virtual PostingAttempt PostingAttempt { get; set; }

    public virtual ICollection<PostingResultErrorDetail> PostingResultErrorDetail { get; set; } = new List<PostingResultErrorDetail>();
}