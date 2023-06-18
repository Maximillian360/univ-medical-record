using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class Urinalysis
{
    public int Id { get; set; }
    public LabResult? labResult { set; get; } 
    
    [DataType(DataType.Date)]
    public DateTime DateRetrieved { get; set; }
    public string? Color { get; set; }
    public string? Appearance { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Ph { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Specgrav { get; set; }
    public string? EpithelialCells { get; set; }
    public string? MucusThread { get; set; }
    public string? AmorphousUrates { get; set; }
    public string? AmorphousPhosphates { get; set; }
    public string? Albumin { get; set; }
    public string? Sugar { get; set; }
    public string? Pregnancy { get; set; }
    public string? Crystals { get; set; }
    public string? Casts { get; set; }
    public string? OthersUrinalysis { get; set; }
    public string? PusCells { get; set; }
    public string? Rbc { get; set; }
    public string? Bacteria { get; set; }
    public string? YeastCells { get; set; }
    public string? OthersMicroAnalysis { get; set; }
}