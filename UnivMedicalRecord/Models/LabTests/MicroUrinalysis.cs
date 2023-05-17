using System.ComponentModel.DataAnnotations.Schema;
using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class MicroUrinalysis
{
    public int Id { get; set; }
    public User User { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal RBC { get; set; }
    public string EpithelialCells { get; set; }
    public string Bacteria { get; set; }
    
}