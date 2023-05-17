using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class CBC
{
    public int Id { get; set; }
    public User User { set; get; } 
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
    public decimal? Mcv { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Mch { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Mchc { get; set; }
    
}