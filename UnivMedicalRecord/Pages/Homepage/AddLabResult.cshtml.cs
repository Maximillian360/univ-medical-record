using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class AddLabResult : PageModel
{
    private readonly DatabaseContext _context;

    public AddLabResult(DatabaseContext context)
    {
        _context = context;
    }
    [BindProperty]
    [Display(Name = "Complete Blood Count:")]
    public string? CbcRes { get; set; }
    
    [BindProperty]
    [Display(Name = "Cholesterol:")]
    public string? CholesterolRes { get; set; }
    
    [BindProperty]
    [Display(Name = "Fecalysis:")]
    public string? FecalysisRes { get; set; }
    
    [BindProperty]
    [Display(Name = "Urinalysis:")]
    public string? UrinalysisRes { get; set; }
    
    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPost()
    {
        var user = HttpContext.Session.GetLoggedInUser(_context);
        var labtest = new LabResult()
        {
            User = user,
            CbcRes = CbcRes,
            CholesterolRes = CholesterolRes,
            FecalysisRes = FecalysisRes,
            UrinalysisRes = UrinalysisRes,
            Encoded = false
        };
        _context.AddLabResult(labtest);
        _context.SaveChanges();

        return RedirectToPage("../Homepage/Index");
    }
    
}