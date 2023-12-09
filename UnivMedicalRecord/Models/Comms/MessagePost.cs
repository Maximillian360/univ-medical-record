using System.ComponentModel.DataAnnotations;
using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Models.Comms;

public class MessagePost
{
    public int Id { get; set; }
    public User User { get; set; }
    public string Recipient { get; set; }
    public byte[] message { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    
    
}