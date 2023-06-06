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
        Messages =_context.MessagePosts.Where(x => x.Recipient == user.Username);
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
        HttpContext.Session.Logout();
        return RedirectToPage("./AddLabTest");
        
    }
    
    public IActionResult OnPostRedirect()
    {
        //HttpContext.Session.Logout();
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

    public IActionResult OnPostViewMedical()
    {
        return RedirectToPage("./ViewRecords");
    }
    public IActionResult OnPostLabResult()
    {
        return RedirectToPage("./AddLabResult");
    }
    public IActionResult OnPostInbox()
    {
        return RedirectToPage("./Inbox");
    }
    
}
