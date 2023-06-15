using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;
using UniversityMedicalRecord.Models;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class Records : PageModel
{
    private readonly DatabaseContext _context;

    public Records(DatabaseContext context)
    {
        _context = context;
    }
    
    public List<Urinalysis> Urinalysis { get; set; }
    public List<Fecalysis> Fecalysis { get; set; }
    public List<CholesterolSI> CholesterolSi { get; set; }
    public List<Cholesterol> Cholesterol { get; set; }
    public List<CBC> Cbcs { get; set; }
    public List<Personal> Personals { get; set; }
    

    public IActionResult OnGet()
    {
        Personals = (List<Personal>)_context.GetPersonals();
        Urinalysis = (List<Urinalysis>)_context.GetUrinalysis();
        Fecalysis = (List<Fecalysis>)_context.GetFecalysis();
        CholesterolSi = (List<CholesterolSI>)_context.GetCholesterolSis();
        Cholesterol = (List<Cholesterol>)_context.GetCholesterol();
        Cbcs = (List<CBC>)_context.GetBloodCount();
        
        return Page();
    }
    public IActionResult OnPostEditButton()
    {
        return RedirectToPage("./AdminMedicalRecordEdit");
    }

    public IActionResult OnPostDashboard()
    {
        return RedirectToPage("./Index");
    }
    
}