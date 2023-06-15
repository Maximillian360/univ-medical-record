using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversityMedicalRecord.Data;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class EditRecord : PageModel
{
    private readonly DatabaseContext _context;

    public EditRecord(DatabaseContext context)
    {
        _context = context;
    }
    [BindProperty]
    public Personal Personal { get; set; }
    
    [BindProperty]
    public FamilyInfo FamilyInfo { get; set; }
    
    [BindProperty]
    public Medical Medical { get; set; }
    
    public IActionResult OnGet(int? id)
    {
        if (id == null || _context.Personals == null)
        {
            return NotFound();
        }

        var personal = _context.Personals.FirstOrDefault(x => x.Id == id);
        var family = _context.FamilyInfos.FirstOrDefault(x => x.Id == id);
        var medical = _context.Medicals.FirstOrDefault(x => x.Id == id);
        
        if (personal == null || family == null || medical == null)
        {
            return NotFound();
        }
        
        Personal = personal;
        FamilyInfo = family;
        Medical = medical;
        
        return Page();
    }

    public IActionResult OnPostUpdate()
    {
        _context.Attach(Personal).State = EntityState.Modified;
        _context.Attach(FamilyInfo).State = EntityState.Modified;
        _context.Attach(Medical).State = EntityState.Modified;

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