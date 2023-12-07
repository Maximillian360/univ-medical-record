using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversityMedicalRecord.Data;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class EditCholesterol : PageModel
{
    private readonly DatabaseContext _context;
    private readonly IWebHostEnvironment webHostEnvironment;

    public EditCholesterol(DatabaseContext context, IWebHostEnvironment hostEnvironment)
    {
        _context = context;
        webHostEnvironment = hostEnvironment;
    }
    
    [BindProperty]
    public Cholesterol Cholesterol { get; set; }
    [BindProperty]
    public string? CholesPath { get; set; }
    
    //[BindProperty]
    //public CholesterolSI CholesterolSi { get; set; }
    
    public IActionResult OnGet(int? id)
    {
        var cholesterol = _context.Cholesterols.FirstOrDefault(x => x.Id == id);
        Cholesterol = cholesterol;
        var labresult = _context.GetLabResult().FirstOrDefault(x => x.Id == id);
        
        CholesPath = Path.Combine("\\images", labresult.CholesterolRes);
        
        return Page();
    }

    public IActionResult OnPostUpdate()
    {
        _context.Attach(Cholesterol).State = EntityState.Modified;
        //_context.Attach(CholesterolSi).State = EntityState.Modified;
        _context.SaveChanges();
        
        return RedirectToPage("../Homepage/Records");
    }
    
    public IActionResult OnPostRecords()
    {
        return RedirectToPage("../Homepage/Records");
    }
    
    public IActionResult OnPostDashboard()
    {
        return RedirectToPage("../Homepage/Index");
    }
}