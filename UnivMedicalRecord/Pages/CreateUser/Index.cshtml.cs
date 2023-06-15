using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;
using UniversityMedicalRecord.Models;
using UniversityMedicalRecord.Models.Admin;
using UniversityMedicalRecord.Models.Employee;
using UnivMedicalRecord.Models.Record;

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
    
    public IActionResult OnGet()
    {
        HasSuperAdmin = _context.HasSuperAdmin();

        if (HasSuperAdmin)
        {
            var user = HttpContext.Session.GetLoggedInUser(_context);
            if (user == null) return RedirectToPage("../Login/Index");

            if (user.Type != Models.UserType.Admin ||
                _context.GetAdminRoles(user).All(x => x.Position != Position.SuperAdmin))
                return RedirectToPage("../HomePage/Index"); // TODO: Show an error that they should be a super admin
        }

        PageTitle = !HasSuperAdmin ? "Create super admin" : "Create user";
        return Page();
    }
    
    public IActionResult OnPost()
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

        var user = new User
        {
            Type = UserType == "admin" || !HasSuperAdmin ? Models.UserType.Admin : Models.UserType.Regular,
            Firstname = FirstName,
            Middlename = MiddleName,
            Lastname = LastName,
            Username = Username,
            PasswordHash = passwordHash,
            PasswordSalt = Convert.ToBase64String(passwordSalt)
        };

        _context.AddUser(user);

        if (!HasSuperAdmin)
        {
            var superAdminRole = new AdminRole
            {
                Admin = user,
                Position = Position.SuperAdmin
            };
        
            _context.AdminRoles.Add(superAdminRole);
        }
        else switch (UserType)
        {
            case "student":
            {
                var newStudent = new EmployeeRole()
                {
                    Employee = user,
                    EmployeePosition = EmployeePosition.Student
                };
        
                _context.EmployeeRoles.Add(newStudent);
                
                var labresult = new LabResult()
                {
                    User = user,
                    CbcRes = null,
                    CholesterolRes = null,
                    FecalysisRes = null,
                    CholesEncoded = false,
                    FecalEncoded = false,
                    UrinalEncoded = false,
                    CbcEncoded = false,
                };
                _context.AddLabResult(labresult);
                
                break;
            }
            case "faculty":
            {
                var newFaculty = new EmployeeRole()
                {
                    Employee = user,
                    EmployeePosition = EmployeePosition.Faculty
                };
        
                _context.EmployeeRoles.Add(newFaculty);
                
                var labresult = new LabResult()
                {
                    User = user,
                    CbcRes = null,
                    CholesterolRes = null,
                    FecalysisRes = null,
                    CholesEncoded = false,
                    FecalEncoded = false,
                    UrinalEncoded = false,
                    CbcEncoded = false,
                };
                _context.AddLabResult(labresult);
                
                break;
            }
        }
        
        _context.SaveChanges();
        
        
        
        var isNotLoggedIn = !HttpContext.Session.IsLoggedIn();
        if (isNotLoggedIn)
        {
            HttpContext.Session.Login(user);
        }
        
        return RedirectToPage("../Login/Index");
    }
    public void SetUserType(string userType)
    {
        UserType = userType;
    }
}