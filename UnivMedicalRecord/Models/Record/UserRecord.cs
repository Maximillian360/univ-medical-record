using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class UserRecord
{
    public int Id { get; set; }
    public Allergy Allergy { get; set; }
    public FamilyInfo FamilyInfo { get; set; }
    public Illness Illness { get; set; }
    public Personal Personal { get; set; }
    public bool HasRecord { get; set; }
}