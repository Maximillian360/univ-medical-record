using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UniversityMedicalRecord.Data;
using UniversityMedicalRecord.Models;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class GeneralRecords : PageModel
{
    private readonly DatabaseContext _context;

    public GeneralRecords(DatabaseContext context)
    {
        _context = context;
    }

    [BindProperty]

    public string FullName { get; set; }
    
    [BindProperty]
    
 
    public int Age { get; set; }
    
    [BindProperty]
 
    public string Gender { get; set; }
    
    [BindProperty]
   
    public string Email { get; set; }

    [BindProperty]
    
    public string MobileNumber { get; set; }
    
    [BindProperty]

    public string IdNumber { get; set; }
    
    [BindProperty]
 
    public DateTime Date { get; set; }
    
    [BindProperty]

    public string BirthPlace { get; set; }
    
    [BindProperty]

    public string Address { get; set; }
    
    [BindProperty]
  
    public string? Doctor { get; set; }
    
    [BindProperty]

    public string? Insurance { get; set; }
    
    [BindProperty]
    public string MotherName { get; set; }
    
    [BindProperty]

    public string MotherAddress { get; set; }
    
    [BindProperty]

    public string MotherNumber { get; set; }
    
    [BindProperty]
  
    public string MotherOccupation { get; set; }
    
    [BindProperty]

    public string MotherStatus { get; set; }
    [BindProperty]

    public string FatherName { get; set; }
    
    [BindProperty]

    public string FatherAddress { get; set; }
    
    [BindProperty]

    public string FatherNumber { get; set; }
    
    [BindProperty]

    public string FatherOccupation { get; set; }
    
    [BindProperty]

    public string FatherStatus { get; set; }
    
    [BindProperty]

    public string GuardianName { get; set; }
    
    [BindProperty]

    public string GuardianAddress { get; set; }
    
    [BindProperty]

    public string GuardianNumber { get; set; }
    
    [BindProperty]
 
    public string GuardianOccupation { get; set; }
    
    [BindProperty]

    public string GuardianStatus { get; set; }

    [BindProperty]

    public string GuardianRelation { get; set; }
    
    [BindProperty]

    public string Allergy { get; set; }
    
    [BindProperty]
    
    public string Illness { get; set; }

    public string Name { get; set; }
    
    public List<Personal> Personals { get; set; }
    public User User { get; set; }
        
    public IActionResult OnGet()
    {
        var user = HttpContext.Session.GetLoggedInUser(_context);
        Personals = (List<Personal>)_context.GetPersonals();
        User = user;
        
        if (HasRecord())
        {
            //WIP: ViewOnly record
            return RedirectToPage("./ViewMedical");
        }
        Name = HttpContext.Session.GetLoggedInUser(_context).Firstname;
        return Page();

    }
    
    public bool HasRecord()
    {
        return Personals.Any(x => x.user == User);
    }

    public IActionResult OnPostSubmit()
    {
        var user = HttpContext.Session.GetLoggedInUser(_context);
        
        var personal = new Personal()
            {
                user = user,
                Name = FullName,
                Age = Age,
                Sex = Gender,
                MobileNumber = MobileNumber,
                Email = Email,
                IdNumber = IdNumber,
                DateOfBirth = Date,
                PlaceOfBirth = BirthPlace,
                Address = Address,
                PersonalDoctor = Doctor,
                Insurance = Insurance
            };
            
            var family = new FamilyInfo()
            {
                user = user,
                MotherName = MotherName,
                MotherStatus = MotherStatus,
                MotherAddress = MotherAddress,
                MotherOccupation = MotherOccupation,
                MotherNumber = MobileNumber,
                FatherName = FatherName,
                FatherStatus = FatherStatus,
                FatherNumber = FatherNumber,
                FatherOccupation = FatherOccupation,
                FatherAddress = FatherOccupation,
                GuardianName = GuardianName,
                GuardianOccupation = GuardianOccupation,
                GuardianAddress = GuardianAddress,
                GuardianStatus = GuardianStatus,
                GuardianRelation = GuardianRelation
            };

            var medical = new Medical()
            {
                user = user,
                Allergy = Allergy,
                Illness = Illness
            };
            
            _context.AddRecord(personal, medical, family);

            _context.SaveChanges();
            
            return RedirectToPage("../Homepage/Index");

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