﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models;

public partial class NonWeekendHoliday
{
    public long NonWeekendHolidayId { get; set; }

    public byte ProcessingUnitId { get; set; }

    public DateTime Holiday { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public virtual ProcessingUnit ProcessingUnit { get; set; }
}