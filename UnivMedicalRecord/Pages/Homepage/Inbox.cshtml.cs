using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;
using UniversityMedicalRecord.Models;
using UnivMedicalRecord.Models.Comms;

namespace UnivMedicalRecord.Pages.Homepage;

public class Inbox : PageModel
{
    private readonly DatabaseContext _context;
    public Inbox(DatabaseContext context)  {
        _context = context;
    }
    
    public MessagePost Messages { get; set; }
      
    public IQueryable<MessagePost> MessageList { get; set; }
    public IQueryable<User> Users { get; set; }
    [BindProperty]
    public string Name { get; set; }
    [BindProperty]
    public string Type { get; set; }

    public List<string> MessageRecieved { get; set; } = new();
    public List<string> From { get; set; } = new();
    public List<string> DateRecieved { get; set; } = new();
    
    public List<int> MessageId { get; set; } = new();
    
    public IQueryable<User> requestUser { get; set; }
    
    public IActionResult OnGet()
    {
        
        var encryptionService = new StringEncryptionService();
        var user = HttpContext.Session.GetLoggedInUser(_context);
        MessageList = _context.MessagePosts.Where(x => x.Recipient == user.Username);
        
        var userList = _context.Users.Where(x=>x.Type == UserType.Regular);
        Users = userList;
        const string passphrase = "Sup3rS3curePass!";
        var requestedUser = _context.Users.Where(x=> x.Type == UserType.Regular);
        requestUser = requestedUser;
        
        
        foreach (var msg in MessageList)
        {
            var decrypted =  encryptionService.Decrypt(msg.message, passphrase);
            From.Add(msg.User.Firstname);
            DateRecieved.Add(msg.Date.ToLongDateString());
            MessageRecieved.Add(decrypted);
            MessageId.Add(msg.Id);

        }

      
        
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

    public IActionResult OnPostDelete(int? id)
    {
        if (id == null) {
            return NotFound();
        }
        
        Messages = _context.MessagePosts.FirstOrDefault(x => x.Id == id);
        _context.RemoveMessage(Messages); 
        _context.SaveChanges();
        return RedirectToPage("./Inbox");
    }
    public IActionResult OnPostCompose()
    {
        return RedirectToPage("./Message");
    }
    
    public IActionResult OnPostRequest(int? id)
    {
        var user = HttpContext.Session.GetLoggedInUser(_context);
        var requestedUser = _context.Users.FirstOrDefault(x=>x.Id == id && x.Type == UserType.Regular);

        requestedUser.IsRequested = true;
        _context.SaveChanges();
        
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
    public IActionResult OnPostClose()
    {
        return RedirectToPage("./Index");
    }
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
        return RedirectToPage("../GeneralRecord/GeneralRecords");
    }

    public IActionResult OnPostViewRecords()
    {
        return RedirectToPage("./Records");
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
    
}