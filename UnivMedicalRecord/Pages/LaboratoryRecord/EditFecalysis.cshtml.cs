using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversityMedicalRecord.Data;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class EditFecalysis : PageModel
{
    private readonly DatabaseContext _context;
    private readonly IWebHostEnvironment webHostEnvironment;

    public EditFecalysis(DatabaseContext context,  IWebHostEnvironment hostEnvironment)
    {
        _context = context;
        webHostEnvironment = hostEnvironment;
    }
    [BindProperty]
    public Fecalysis Fecalysis { get; set; }
    
    [BindProperty]
    public string? FecalPath { get; set; }
    
    
    public IActionResult OnGet(int? id)
    {
        if (id == null || _context.Fecalyses == null)
        {
            return NotFound();
        }
        
        var fecalysis = _context.Fecalyses.FirstOrDefault(X => X.Id == id);
        
        if (fecalysis == null)
        {
            return NotFound();
        }
        
        Fecalysis = fecalysis;
        var labresult = _context.GetLabResult().FirstOrDefault(x => x.Id == id);
        FecalPath =  Path.Combine("\\images", labresult.FecalysisRes);
        return Page();
    }

    public IActionResult OnPostUpdate()
    {
        _context.Attach(Fecalysis).State = EntityState.Modified;
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