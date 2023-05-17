using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class Illness
{
    public int Id { get; set; }
    public User User { get; set; }
    public string? IllnessName { get; set; }
}