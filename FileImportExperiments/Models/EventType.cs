﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models;

public partial class EventType
{
    public string EventTypeCode { get; set; }

    public string EventTypeDescription { get; set; }

    public int? ExpectedProductivity { get; set; }

    public virtual ICollection<Event> Event { get; set; } = new List<Event>();

    public virtual ICollection<WorkflowDataCenter> WorkflowDataCenter { get; set; } = new List<WorkflowDataCenter>();
}