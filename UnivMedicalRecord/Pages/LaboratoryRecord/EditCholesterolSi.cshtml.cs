using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversityMedicalRecord.Data;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class EditCholesterolSi : PageModel
{
    private readonly DatabaseContext _context;
    private readonly IWebHostEnvironment webHostEnvironment;

    public EditCholesterolSi(DatabaseContext context, IWebHostEnvironment hostEnvironment)
    {
        _context = context;
        webHostEnvironment = hostEnvironment;
    }

    
    [BindProperty]
    public CholesterolSI CholesterolSi { get; set; }
    
    [BindProperty]
    public string? CholesSiPath { get; set; }
    
    public IActionResult OnGet(int? id)
    {
        var cholesterolSi = _context.CholesterolSis.FirstOrDefault(x => x.Id == id);
        CholesterolSi = cholesterolSi;
        var labresult = _context.GetLabResult().FirstOrDefault(x => x.Id == id);
        
        CholesSiPath = Path.Combine("\\images", labresult.CholesterolSiRes);
        
        return Page();
    }

    public IActionResult OnPostUpdate()
    {
        _context.Attach(CholesterolSi).State = EntityState.Modified;
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