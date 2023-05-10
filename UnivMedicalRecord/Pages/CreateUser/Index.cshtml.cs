using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;
using UniversityMedicalRecord.Models;
using UniversityMedicalRecord.Models.Admin;
using UniversityMedicalRecord.Models.Employee;

namespace UniversityMedicalRecord.Pages.CreateUser;

public class IndexModel : PageModel
{
    private readonly DatabaseContext _context;

    public IndexModel(DatabaseContext context)
    {
        _context = context;
    }
    
    public bool HasSuperAdmin { get; set; }
    public string PageTitle { get; set; }
    [BindProperty] public string UserType { get; set; }
    
    [BindProperty]
    [Display(Name = "First name")]
    public string FirstName { get; set; }
    
    [BindProperty]
    [Display(Name = "Middle name")]
    public string? MiddleName { get; set; }
    
    [BindProperty]
    [Display(Name = "Last name")]
    public string LastName { get; set; }
    
    [BindProperty]
    [Display(Name = "Username")]
    public string Username { get; set; }
    
    [BindProperty]
    [Display(Name = "Password")]
    public string Password { get; set; }
    
    public void OnGetAsync()
    {
        HasSuperAdmin = _context.HasSuperAdmin();
        PageTitle = !HasSuperAdmin ? "Create admin" : "Create user";
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        //TODO: REMOVE REDUNDANCY
        HasSuperAdmin = _context.HasSuperAdmin();
        var isUsernameDuplicate = _context.GetUsers().Any(x => x.Username == Username);
        
        if (!ModelState.IsValid || isUsernameDuplicate)
        {
            return Page();
        }

        var passwordSalt = PasswordHash.GenerateSalt();
        var passwordHash = Password.ComputeHash(passwordSalt);

        var user = UserType == "admin" || !HasSuperAdmin
            ? new Admin()
            {
                Firstname = FirstName,
                Middlename = MiddleName,
                Lastname = LastName,
                Username = Username,
                PasswordHash = passwordHash,
                PasswordSalt = Convert.ToBase64String(passwordSalt)
            }
            : new Employee()
            {
                Firstname = FirstName,
                Middlename = MiddleName,
                Lastname = LastName,
                Username = Username,
                PasswordHash = passwordHash,
                PasswordSalt = Convert.ToBase64String(passwordSalt)
            } as User;

        _context.AddUser(user);

        var superAdminRole = new AdminRole
        {
            Admin = (user as Admin)!,
            Position = Position.SuperAdmin
        };
        
        _context.AdminRoles.Add(superAdminRole);
        
        await _context.SaveChangesAsync();
        
        return RedirectToPage("./Index");
    }
    
}