
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversityMedicalRecord.Data;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class EditUrinalysis : PageModel
{
    private readonly DatabaseContext _context;

    public EditUrinalysis(DatabaseContext context)
    {
        _context = context;
    }
    
    [BindProperty]
    public Urinalysis Urinalysis { get; set; }
    
    public IActionResult OnGet(int? id)
    {
        var urinalysis = _context.Urinalyses.FirstOrDefault(x=>x.Id == id);
        Urinalysis = urinalysis;
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