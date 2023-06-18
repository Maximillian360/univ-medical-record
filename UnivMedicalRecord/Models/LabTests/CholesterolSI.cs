using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class CholesterolSI
{
    public int Id { get; set; }
    public LabResult labResult { set; get; }  
    
    [DataType(DataType.Date)]
    public DateTime DateRetrieved { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? SiFbs { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? SiBun { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? SiCreatinine { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? SiBua { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? SiCholesterol { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? SiTriglyceride { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? SiDhdl { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? SiLdl { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Sgot { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Sgpt { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Amylase { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Ckmb { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Sodium { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Potassium { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Chloride { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? IonizedCalcium { get; set; }
    
}