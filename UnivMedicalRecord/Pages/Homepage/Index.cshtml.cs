﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;
using UniversityMedicalRecord.Models;

namespace UnivMedicalRecord.Pages.Homepage;

public class IndexModel : PageModel
{
    private readonly DatabaseContext _context;

    public IndexModel(DatabaseContext context)  {
        _context = context;
    }
    
    [BindProperty]
    public string Name { get; set; }
    [BindProperty]
    public string Type { get; set; }
    public IActionResult OnGet()
    {
        var user = HttpContext.Session.GetLoggedInUser(_context);
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

    public IActionResult OnPostLogout()
    {
        HttpContext.Session.Logout();
        return RedirectToPage("../Index");
        
    }
    public IActionResult OnPostCreateAccount()
    {
        
        return RedirectToPage("../CreateUser/Index");
        
    }
    
}
