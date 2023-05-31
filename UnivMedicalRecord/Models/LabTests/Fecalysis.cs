using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class Fecalysis
{
    public int Id { get; set; }
    public User User { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateRetrieved { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? StoolPusCells { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? StoolRbc { get; set; }
    public string? Color { get; set; }
    public string? Consistency { get; set; }
    public string? OtherFindings { get; set; }
    public string? OccultBlood { get; set; }
    public string? MicroOtherFindings { get; set; }
    public string? MicroRemarks { get; set; }
    public string? StoolRemarks { get; set; }
    public string? FurtherRemarks { get; set; }
}