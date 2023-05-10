namespace UniversityMedicalRecord.Models.Employee;

public class EmployeeRole
{
    public int Id { get; set; }
    public Employee Employee { get; set; }
    public EmployeePosition EmployeePosition { get; set; }
}