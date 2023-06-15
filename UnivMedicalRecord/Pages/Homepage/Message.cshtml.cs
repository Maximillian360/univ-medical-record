using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;
using UniversityMedicalRecord.Models;
using UnivMedicalRecord.Models.Comms;
using System.Security.Cryptography;
namespace UnivMedicalRecord.Pages.Homepage;

public class Message : PageModel
{
    private readonly DatabaseContext _context;

    public Message(DatabaseContext context)
    {
        _context = context;
    }
    
    [BindProperty]
    [Display(Name = "Recipient")]
    public string Recipient { get; set; }
    
    [BindProperty]
    
    [Display(Name = "Message")]
    public string message { get; set; }
    public IQueryable<User> ListOfRecipient { get; set; }

    public IActionResult OnGet()
    {
        var user = HttpContext.Session.GetLoggedInUser(_context);
        if (user.Type == UserType.Admin)
        { 
            var recipients = _context.Users.Where(x => x.Type == UserType.Regular);
            ListOfRecipient = recipients;
        }
        else
        {
            var recipients = _context.Users.Where(x => x.Type == UserType.Admin);
            ListOfRecipient = recipients;
        }

        return Page();
    }
    public IActionResult OnPostSend()
    {
        var user = HttpContext.Session.GetLoggedInUser(_context);
        var encryptionService = new StringEncryptionService();
        const string passphrase = "Sup3rS3curePass!";
        var encrypted = encryptionService.Encrypt(message,
            passphrase);
        
        
        var newmessage = new MessagePost()
        {
            Date = DateTime.Today,
            User = user,
            Recipient = Recipient,
            message = encrypted,
        };

        _context.WriteMessage(newmessage);
        _context.SaveChanges();
        return RedirectToPage("./Inbox");
    }

    public IActionResult OnPostDiscard()
    {
        return RedirectToPage("./Inbox");
    }
}