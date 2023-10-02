﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FileImportExperiments.Models;

public partial class ImageBatch
{
    public long ImageBatchId { get; set; }

    public string BatchTitle { get; set; }

    public DateTime BatchCreationDate { get; set; }

    public string ImageBatchFileName { get; set; }

    public long MidasBatchId { get; set; }

    public int MidasPackageId { get; set; }

    public long DateOfFileId { get; set; }

    public long BeginningImageBatchDocumentReferenceId { get; set; }

    public long EndingImageBatchDocumentReferenceId { get; set; }

    public DateTime VendorExpectedReceiptDate { get; set; }

    public bool? IsVendorSuccessful { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public long? ReplacedWithImageBatchId { get; set; }

    public DateTime? VendorActualReceiptDate { get; set; }

    public int? VendorTurnaroundTimeMinutes { get; set; }

    public int? EstimatedDocCount { get; set; }

    public int? VendorActualDocCount { get; set; }

    public bool? IsPartialDateOfFile { get; set; }

    public int? MpcPerformanceTargetHours { get; set; }

    public int? MpcTurnaroundTimeMinutes { get; set; }

    public bool? IsMpcSuccessful { get; set; }

    public int? VendorPerformanceTargetHours { get; set; }

    public int? DataCenterPerformanceTargetHours { get; set; }

    public DateTime? DataCenterExpectedCertificationDate { get; set; }

    public DateTime? DataCenterActualCertificationDate { get; set; }

    public bool? IsDataCenterSuccessful { get; set; }

    public int? OverallTurnaroundTimeMinutes { get; set; }

    public bool? IsOverallSuccessful { get; set; }

    public virtual ImageBatchDocumentReference BeginningImageBatchDocumentReference { get; set; }

    public virtual DateOfFile DateOfFile { get; set; }

    public virtual ICollection<DocumentDescriptionRcvd> DocumentDescriptionRcvd { get; set; } = new List<DocumentDescriptionRcvd>();

    public virtual ImageBatchDocumentReference EndingImageBatchDocumentReference { get; set; }

    public virtual ICollection<ImageBatchFtpUpload> ImageBatchFtpUpload { get; set; } = new List<ImageBatchFtpUpload>();

    public virtual ICollection<ImageBatch> InverseReplacedWithImageBatch { get; set; } = new List<ImageBatch>();

    public virtual ImageBatch ReplacedWithImageBatch { get; set; }
}