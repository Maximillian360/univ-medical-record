using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;
using UnivMedicalRecord.Models.Comms;

namespace UnivMedicalRecord.Pages.Homepage;

public class Inbox : PageModel
{
    private readonly DatabaseContext _context;
    public Inbox(DatabaseContext context)  {
        _context = context;
    }
    
    public IQueryable<MessagePost> Messages { get; set; }

    public IActionResult OnGet()
    {
        var user = HttpContext.Session.GetLoggedInUser(_context);
        Messages = _context.MessagePosts.Where(x => x.Recipient == user.Username);
        return Page();
    }
    public IActionResult OnPostCompose()
    {
        return RedirectToPage("./Message");
    }
    public IActionResult OnPostClose()
    {
        return RedirectToPage("./Index");
    }
}