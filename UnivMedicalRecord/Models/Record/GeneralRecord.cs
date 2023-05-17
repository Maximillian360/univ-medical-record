using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;
using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class GeneralRecord
{
    public int Id { get; set; }
    public User User { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Sex { get; set; }
    public string MobileNumber { get; set; }
    public string IdNumber { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    public string? PlaceOfBirth { get; set; }
    public string Address { get; set; }
    public string? PersonalDoctor { get; set; }
    public string? Insurance { get; set; }
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
    [DataType(DataType.Date)]
    public DateTime DateSigned { get; set; }
    
    
}