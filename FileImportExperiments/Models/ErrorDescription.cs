﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models;

public partial class ErrorDescription
{
    public long ErrorDescriptionId { get; set; }

    public string ErrorType { get; set; }

    public string Code { get; set; }

    public string Message { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public virtual ICollection<PostingResultErrorDetail> PostingResultErrorDetail { get; set; } = new List<PostingResultErrorDetail>();
}