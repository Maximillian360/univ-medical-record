using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class Urinalysis
{
    public int Id { get; set; }
    public User User { get; set; }
    public DateOnly DateRetrieved { get; set; }
    public string Color { get; set; }
    public string Appearance { get; set; }
    public string Glucose { get; set; }
    public string Bilirubin { get; set; }
    public string Ketone { get; set; }
    public decimal Specgrav { get; set; }
    public string Blood { get; set; }
    public decimal Ph { get; set; }
    public string Protein { get; set; }
    public decimal Urobilinogen { get; set; }
    public decimal Nitrite { get; set; }
    public string Leukesterase { get; set; }

}