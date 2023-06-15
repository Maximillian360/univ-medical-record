using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversityMedicalRecord.Data;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class EditCholesterol : PageModel
{
    private readonly DatabaseContext _context;

    public EditCholesterol(DatabaseContext context)
    {
        _context = context;
    }
    
    [BindProperty]
    public Cholesterol Cholesterol { get; set; }
    
    [BindProperty]
    public CholesterolSI CholesterolSi { get; set; }
    
    public IActionResult OnGet(int? id)
    {
        var cholesterol = _context.Cholesterols.FirstOrDefault(x => x.Id == id);
        var cholesterolSi = _context.CholesterolSis.FirstOrDefault(x => x.Id == id);
        Cholesterol = cholesterol;
        CholesterolSi = cholesterolSi;
        
        return Page();
    }

    public IActionResult OnPostUpdate()
    {
        _context.Attach(Cholesterol).State = EntityState.Modified;
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