using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class Urinalysis
{
    public int Id { get; set; }
    public User User { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateRetrieved { get; set; }
    public string Color { get; set; }
    public string Appearance { get; set; }
    public string Glucose { get; set; }
    public string Bilirubin { get; set; }
    public string Ketone { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Specgrav { get; set; }
    public string Blood { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Ph { get; set; }
    public string Protein { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Urobilinogen { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Nitrite { get; set; }
    public string Leukesterase { get; set; }

}