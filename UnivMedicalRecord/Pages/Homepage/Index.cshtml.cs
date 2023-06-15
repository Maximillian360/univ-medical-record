using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;
using UniversityMedicalRecord.Models;
using UnivMedicalRecord.Models.Comms;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class IndexModel : PageModel
{
    private readonly DatabaseContext _context;
    public IndexModel(DatabaseContext context)  {
        _context = context;
    }
    
    public IQueryable<MessagePost> Messages { get; set; }
    public IActionResult OnGet()
    {
        var user = HttpContext.Session.GetLoggedInUser(_context);
        var userList = _context.Users.Where(x=>x.Type == UserType.Regular);
        var lablist = _context.LabResults;
        var pendinglab = _context.GetLabResult().Where(x=>x.CholesterolRes != null & x.FecalysisRes != null & x.UrinalysisRes != null & x.CbcRes != null && x.CbcEncoded == false || x.CholesEncoded == false || x.UrinalEncoded == false || x.CbcEncoded == false);
        
        PendingLab = pendinglab;
        LabList = lablist;
        Users = userList;
        
        switch (user)
        {
            case null:
                return RedirectToPage("../Login/Index");
            default:
                Name = $"{user.Firstname} {user.Lastname}";
                Type = $"{user.Type}";
                
                
                
                return Page();
        }
        
    }
  
    public IQueryable<User> Users { get; set; }
    [BindProperty]
    public string Name { get; set; }
    [BindProperty]
    public string Type { get; set; }
    
    public IEnumerable<LabResult> PendingLab { get; set; }
    public IQueryable<LabResult> LabList { get; set; }
    public IEnumerable<LabResult> LabResultChecker { get; set; }
    public IEnumerable<LabResult> LabResultChecker1 { get; set; }
    public bool test { get; set; }

    public IActionResult OnPostLogout()
    {
        HttpContext.Session.Logout();
        return RedirectToPage("../Index");
        
    }
    
    public IActionResult OnPostLabTest()
    {
        
        return RedirectToPage("../LaboratoryRecord/AddLab");
        
    }
    
    public IActionResult OnPostRedirect()
    {
        
        return RedirectToPage("./AddLabTest");
        
    }
    public IActionResult OnPostCreateAccount()
    {
        
        return RedirectToPage("../CreateUser/Index");
    }

    public IActionResult OnPostMedicalRecord()
    {
        return RedirectToPage("../GeneralRecord/GeneralRecords");
    }
    
    public IActionResult OnPostLabResult()
    {
        return RedirectToPage("../GeneralRecord/AddLabResult");
    }
    public IActionResult OnPostInbox()
    {
        return RedirectToPage("./Inbox");
    }

    public IActionResult OnPostDashboard()
    {
        return RedirectToPage("./Index");
    }
    public IActionResult OnPostViewRecords()
    {
        return RedirectToPage("./Records");
    }
    
}
