using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
    [Display(Name = "Fullname")]
    public string FullName { get; set; }
    
    [BindProperty]
    
    [Display(Name = "Age")]
    public int Age { get; set; }
    
    [BindProperty]
    [Display(Name = "Gender")]
    public string Gender { get; set; }
    
    [BindProperty]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [BindProperty]
    [Display(Name= "Mobile Number")]
    public string MobileNumber { get; set; }
    
    [BindProperty]
    [Display(Name= "IdNumber")]
    public string IdNumber { get; set; }
    
    [BindProperty]
    [Display(Name= "Date")]
    public DateTime Date { get; set; }
    
    [BindProperty]
    [Display(Name= "Birth Place")]
    public string BirthPlace { get; set; }
    
    [BindProperty]
    [Display(Name= "Address")]
    public string Address { get; set; }
    
    [BindProperty]
    [Display(Name= " Personal Doctor")]
    public string? Doctor { get; set; }
    
    [BindProperty]
    [Display(Name= " Do you have any Insurance?")]
    public string? Insurance { get; set; }
    
    [BindProperty]
    [Display(Name= "Name of Mother")]
    public string MotherName { get; set; }
    
    [BindProperty]
    [Display(Name= "Address of Mother")]
    public string MotherAddress { get; set; }
    
    [BindProperty]
    [Display(Name= "Contact Number of Mother")]
    public string MotherNumber { get; set; }
    
    [BindProperty]
    [Display(Name= "Occupation of Mother")]
    public string MotherOccupation { get; set; }
    
    [BindProperty]
    [Display(Name = "Civil Status")]
    public string MotherStatus { get; set; }
    [BindProperty]
    [Display(Name= "Name of Father")]
    public string FatherName { get; set; }
    
    [BindProperty]
    [Display(Name= "Address of Father")]
    public string FatherAddress { get; set; }
    
    [BindProperty]
    [Display(Name= "Contact Number of Father")]
    public string FatherNumber { get; set; }
    
    [BindProperty]
    [Display(Name= "Occupation of Father")]
    public string FatherOccupation { get; set; }
    
    [BindProperty]
    [Display(Name = "Civil Status")]
    public string FatherStatus { get; set; }
    
    [BindProperty]
    [Display(Name= "Name of Gurdian")]
    public string GurdianName { get; set; }
    
    [BindProperty]
    [Display(Name= "Address of Gurdian")]
    public string GurdianAddress { get; set; }
    
    [BindProperty]
    [Display(Name= "Contact Number of Gurdian")]
    public string GurdianNumber { get; set; }
    
    [BindProperty]
    [Display(Name= "Occupation of Gurdian")]
    public string GurdianOccupation { get; set; }
    
    [BindProperty]
    [Display(Name = "Civil Status")]
    public string GurdianStatus { get; set; }

    [BindProperty]
    [Display(Name = "Relationship with the Gurdian")]
    public string GurdianRelation { get; set; }
    
    [BindProperty]
    [Display(Name = "List of Allergies if there's any")]
    public string Allergy { get; set; }
    
    [BindProperty]
    [Display(Name = "List of present or active Illnesses if there's any")]
    
    public string Illness { get; set; }

    public string Name { get; set; }
    
    

    public IActionResult OnGet()
    {
        Name = HttpContext.Session.GetLoggedInUser(_context).Firstname;
        return Page();
        
    }

    public IActionResult OnPost()
    {
        
        
        var personal = new Personal()
            {
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
             GurdianName = GurdianName,
             GurdianOccupation = GurdianOccupation,
             GurdianAddress = GurdianAddress,
             GurdianStatus = GurdianStatus,
             GurdianRelation = GurdianRelation
            };
            
            var allergy = new Allergy()
            {
                
                AllergyName = Allergy
            };

            var illness = new Illness()
            {
                
                IllnessName = Insurance
            };
            
            _context.AddRecord(personal, allergy, family, illness);

            var record = new UserRecord()
            {
                Personal = personal,
                Allergy = allergy,
                FamilyInfo = family,
                Illness = illness,
                HasRecord = true
            };

            _context.AddUserRecord(record);
            
            var user = HttpContext.Session.GetLoggedInUser(_context);
            
            //NOTE: HOW TF IS THIS NULL
            //TODO: CONNECT RECORDS TO CURRENT USER 
            user.UserRecord = record;

            _context.SaveChanges();
            
            return RedirectToPage("../Homepage/Index");

    }

    //BUT ITS NOT NULL HERE WTF
    public IActionResult OnPostTest()
    {
        
        var user = HttpContext.Session.GetLoggedInUser(_context);
        user.Firstname = "Jen Jen";
        Name = user.Firstname;
        _context.SaveChanges();
        return Page();
    }
}