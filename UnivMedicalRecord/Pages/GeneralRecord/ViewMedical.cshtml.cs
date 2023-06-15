using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class ViewMedical : PageModel
{
    private readonly DatabaseContext _context;

    public ViewMedical(DatabaseContext context)
    {
        _context = context;
    }
    
   
    
    public string Name { get; set; }
    public int  Age { get; set; }
    public string  Sex { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string IdNumber { get; set; }
    public DateTime Date { get; set; }
    public string BirthPlace { get; set; }
    public string Address { get; set; }
    public string? Doctor { get; set; }
    public string? Insurance { get; set; }
    public string MotherName { get; set; }
    public string MotherAddress { get; set; }
    public string MotherNumber { get; set; }
    public string MotherOccupation { get; set; }
    public string MotherStatus { get; set; }
    public string FatherName { get; set; }
    public string FatherAddress { get; set; }
    public string FatherNumber { get; set; }
    public string FatherOccupation { get; set; }
    public string FatherStatus { get; set; }
    public string GuardianName { get; set; }
    public string GuardianAddress { get; set; }
    public string GuardianNumber { get; set; }
    public string GuardianOccupation { get; set; }
    public string GuardianStatus { get; set; }
    public string GuardianRelation { get; set; }
    public string Allergy { get; set; }
    public string Illness { get; set; }
    
    public void OnGet()
    {
        var user = HttpContext.Session.GetLoggedInUser(_context);
        var personals = _context.Personals.Where(x => x.user == user);
        var family = _context.FamilyInfos.Where(x => x.user == user).ToList();
        var medical = _context.Medicals.Where(x => x.user == user).ToList();
        
        foreach (var personal in personals)
        {
            Name = personal.Name;
            Age = personal.Age;
            Sex = personal.Sex;
            Email = personal.Email;
            MobileNumber = personal.MobileNumber;
            IdNumber = personal.IdNumber;
            Date = personal.DateOfBirth;
            BirthPlace = personal.PlaceOfBirth;
            Address = personal.Address;
            Doctor = personal.PersonalDoctor;
            Insurance = personal.Insurance;
        }

        foreach (var fam in family)
        {
            MotherName = fam.MotherName;
            MotherAddress = fam.MotherAddress;
            MotherNumber = fam.MotherNumber;
            MotherOccupation = fam.MotherOccupation;
            MotherStatus = fam.MotherStatus;
            FatherName = fam.FatherName;
            FatherAddress = fam.FatherAddress;
            FatherNumber = fam.FatherNumber;
            FatherOccupation = fam.FatherOccupation;
            FatherStatus = fam.FatherStatus;
            GuardianName = fam.GuardianName;
            GuardianAddress = fam.GuardianAddress;
            GuardianOccupation = fam.GuardianOccupation;
            GuardianStatus = fam.GuardianStatus;
            GuardianRelation = fam.GuardianRelation;
        }

        foreach (var med in medical)
        {
            Allergy = med.Allergy;
            Illness = med.Illness;
        }
        


    }
    public IActionResult OnPostLabTest()
    {
        return RedirectToPage("./AddLabResult");
    }
    public IActionResult OnPostDashboard()
    {
        return RedirectToPage("../Homepage/Index");
    }
    
    public IActionResult OnPostInbox()
    {
        return RedirectToPage("../Homepage/Inbox");
    }
    

}