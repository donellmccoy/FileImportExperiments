﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models;

public partial class TaskDetail
{
    public long TaskDetailId { get; set; }

    public long TaskId { get; set; }

    public string TypeOfInstrument { get; set; }

    public string LegalDescription { get; set; }

    public DateTime? DeleteAfterDate { get; set; }

    public string SecondaryReference { get; set; }

    public virtual Task Task { get; set; }
}