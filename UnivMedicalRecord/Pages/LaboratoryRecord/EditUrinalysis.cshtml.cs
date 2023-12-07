
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversityMedicalRecord.Data;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class EditUrinalysis : PageModel
{
    private readonly DatabaseContext _context;
    private readonly IWebHostEnvironment webHostEnvironment;

    public EditUrinalysis(DatabaseContext context, IWebHostEnvironment hostEnvironment)
    {
        _context = context;
        webHostEnvironment = hostEnvironment;
    }
    
    [BindProperty]
    public Urinalysis Urinalysis { get; set; }
    [BindProperty]
    public string? UrinalysisPath { get; set; }
    
    public IActionResult OnGet(int? id)
    {
        var urinalysis = _context.Urinalyses.FirstOrDefault(x=>x.Id == id);
        Urinalysis = urinalysis;
        var labresult = _context.GetLabResult().FirstOrDefault(x => x.Id == id);
        
        UrinalysisPath = Path.Combine("\\images", labresult.UrinalysisRes);
        return Page();
    }

    public IActionResult OnPostUpdate()
    {
        
        _context.Attach(Urinalysis).State = EntityState.Modified;
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