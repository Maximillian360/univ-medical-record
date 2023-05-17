using System.ComponentModel.DataAnnotations;
using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Record;

public class CBC
{
    public int Id { get; set; }
    public User User { set; get; } 
    [DataType(DataType.Date)]
    public DateTime DateRetrieved { get; set; }
    public decimal? Wbc { get; set; }
    public decimal? Rbc { get; set; }
    public decimal? Hb { get; set; }
    public decimal? Hct { get; set; }
    public decimal? Plt { get; set; }
    public decimal? Mcv { get; set; }
    public decimal? Mch { get; set; }
    public decimal? Mchc { get; set; }
    
}