using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;
using UniversityMedicalRecord.Models;
using UnivMedicalRecord.Models.Comms;

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
    

    public IActionResult OnPostLogout()
    {
        HttpContext.Session.Logout();
        return RedirectToPage("../Index");
        
    }
    
    public IActionResult OnPostLabTest()
    {
        
        return RedirectToPage("./AddLab");
        
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
        return RedirectToPage("./GeneralRecords");
    }
    
    public IActionResult OnPostLabResult()
    {
        return RedirectToPage("./AddLabResult");
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
