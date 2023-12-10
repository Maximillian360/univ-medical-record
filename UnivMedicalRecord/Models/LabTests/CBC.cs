using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class CBC
{
    public int Id { get; set; }
    public LabResult? labResult { set; get; } 
    
    
    [DataType(DataType.Date)]
    public DateTime DateRetrieved { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Wbc { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Rbc { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Hb { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Hct { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Plt { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Blast { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Promyelocyte { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Myelocyte { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Metamyelocyte { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Stab { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Segmenter { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Lymphocyte { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Monocyte { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Eosinophil { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Basophil { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Esr { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Reticulocyte { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? BleedingTime { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? ClottingTime { get; set; }
    public string? Malaria { get; set; }
    public string? RedCellMorphology { get; set; }
    public string? Test { get; set; }
    public string? Control { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Activity { get; set; }
    public string? PatientRatio { get; set; }
    public string? Inr { get; set; }
    public string? BloodType { get; set; }
    
    
}