﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models;

public partial class PostingResultErrorDetail
{
    public long PostingResultsErrorDetailId { get; set; }

    public long PostingResultId { get; set; }

    public long ErrorDescriptionId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public virtual ErrorDescription ErrorDescription { get; set; }

    public virtual PostingResult PostingResult { get; set; }
}