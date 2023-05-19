using System.ComponentModel.DataAnnotations;
using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class Personal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Sex { get; set; }
    public string MobileNumber { get; set; }
    public string? Email { get; set; }
    public string IdNumber { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    public string? PlaceOfBirth { get; set; }
    public string Address { get; set; }
    public string? PersonalDoctor { get; set; }
    public string? Insurance { get; set; }
}