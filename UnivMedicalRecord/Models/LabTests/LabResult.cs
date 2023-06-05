using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class LabResult
{
    public int Id { get; set; }
    public User User { get; set; }
    public string? CholesterolRes { get; set; }
    public string? CbcRes { get; set; }
    public string? UrinalysisRes { get; set; }
    public string? FecalysisRes { get; set; }
    public bool Encoded { get; set; }
}