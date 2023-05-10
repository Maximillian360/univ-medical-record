﻿using UniversityMedicalRecord.Models.Employee;

namespace UniversityMedicalRecord.Models.Admin;

public class Admin : User
{
    public override int Id { get; set; }
    public override string Firstname { get; set; }
    public override string? Middlename { get; set; }
    public override string Lastname { get; set; }
    public override string Username { get; set; }

    
    public override string PasswordHash { get; set; }
    public override string PasswordSalt { get; set; }
}