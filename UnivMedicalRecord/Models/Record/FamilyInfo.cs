using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class FamilyInfo
{
    public int Id { get; set; }
    public string? MotherName { get; set; }
    public string? MotherStatus { get; set; }
    public string? MotherAddress { get; set; }
    public string? MotherOccupation { get; set; }
    public string? MotherNumber { get; set; }
    public string? FatherName { get; set; }
    public string? FatherStatus { get; set; }
    public string? FatherAddress { get; set; }
    public string? FatherOccupation { get; set; }
    public string? FatherNumber { get; set; }
    public string GurdianName { get; set; }
    public string GurdianStatus { get; set; }
    public string GurdianAddress { get; set; }
    public string GurdianOccupation { get; set; }
    public string GurdianRelation { get; set; }
}