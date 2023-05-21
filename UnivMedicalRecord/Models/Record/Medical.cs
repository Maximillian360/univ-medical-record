using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class Medical
{
    public int Id { get; set;  }
    public User user { get; set; }
    public string? Allergy { get; set; }
    public string? Illness { get; set; }
    
}