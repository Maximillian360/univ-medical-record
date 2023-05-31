using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class Cholesterol
{
    public int Id { get; set; }
    public User User { set; get; } 
    [DataType(DataType.Date)]
    public DateTime DateRetrieved { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? TradFbs { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? TradBun { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? TradCreatinine { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? TradBua { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? TradCholesterol { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? TradTriglyceride { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? TradDhdl { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? TradLdl { get; set; }
    public string? Remarks { get; set; }
    public string? OtherRemarks { get; set; }
}