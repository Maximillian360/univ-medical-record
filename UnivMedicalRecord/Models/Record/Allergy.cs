﻿using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class Allergy
{
    public int Id { get; set; }
    public User User { get; set; }
    public string? AllergyName { get; set; }
}
    