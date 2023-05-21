using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class ViewRecords : PageModel
{
    private readonly DatabaseContext _context;

    public ViewRecords(DatabaseContext context)
    {
        _context = context;
    }
    
    public List<Personal> Personals { get; set; }

    public IActionResult OnGet()
    {
        Personals = (List<Personal>)_context.GetPersonals();
        return Page();
    }
}