using UnivMedicalRecord.Models.Record;

namespace UniversityMedicalRecord.Models;

public class User 
{
    public int Id { get; set; }
    
    public UserRecord? UserRecord { get; set; }
    public UserType Type { get; set; }
    public string Firstname { get; set; }
    public string? Middlename { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
}