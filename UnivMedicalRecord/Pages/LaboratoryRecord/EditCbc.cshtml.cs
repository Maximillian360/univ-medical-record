using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversityMedicalRecord.Data;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class EditCbc : PageModel
{
    private readonly DatabaseContext _context;

    public EditCbc(DatabaseContext context)
    {
        _context = context;
    }
    [BindProperty]
    public CBC Cbc { get; set; }

    public IActionResult OnGet(int? id)
    {
        var cbc = _context.BloodCounts.FirstOrDefault(x => x.Id == id);
        Cbc = cbc;
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