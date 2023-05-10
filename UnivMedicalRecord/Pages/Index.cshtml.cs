﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;

namespace UnivMedicalRecord.Pages;

public class IndexModel : PageModel
{
    private readonly DatabaseContext _context;
    
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, DatabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        if (!_context.HasSuperAdmin())
        {
            return RedirectToPage("./CreateAdmin/Index");
        }

        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        var userId = HttpContext.Session.GetInt32(Session.UserIdKey);
        if (userId == null) return RedirectToPage("./Login/Index");
        var user = _context.GetUser((int)userId);
        if (user == null) return RedirectToPage("./Login/Index");
        return RedirectToPage("./HomePage/Index");
    }
}