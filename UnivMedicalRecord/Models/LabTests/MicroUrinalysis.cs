using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class MicroUrinalysis
{
    public int Id { get; set; }
    public User User { get; set; }
    public Range RBC { get; set; }
    public string EpithelialCells { get; set; }
    public string Bacteria { get; set; }
    
}