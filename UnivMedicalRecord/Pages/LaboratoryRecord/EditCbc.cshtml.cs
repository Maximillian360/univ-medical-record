using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversityMedicalRecord.Data;
using UniversityMedicalRecord.Models;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class EditCbc : PageModel
{
    private readonly DatabaseContext _context;
    private readonly IWebHostEnvironment webHostEnvironment;

    public EditCbc(DatabaseContext context, IWebHostEnvironment hostEnvironment)
    {
        _context = context;
        webHostEnvironment = hostEnvironment;
    }
    
    [BindProperty]
    public CBC Cbc { get; set; }

    [BindProperty]
    public string? CbcPath { get; set; }
 

    public IActionResult OnGet(int? id)
    {
        
        var cbc = _context.BloodCounts.FirstOrDefault(x => x.Id == id);
        Cbc = cbc;
        var labresult = _context.GetLabResult().FirstOrDefault(x => x.Id == id);
        
            
        CbcPath = Path.Combine("\\images", labresult.CbcRes);
        return Page();
    }
    

    public IActionResult OnPostUpdate()
    {
        _context.Attach(Cbc).State = EntityState.Modified;
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