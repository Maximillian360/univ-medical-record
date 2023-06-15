using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversityMedicalRecord.Data;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class AddLabResult : PageModel
{
    private readonly DatabaseContext _context;
    
    private readonly IWebHostEnvironment webHostEnvironment;

    public AddLabResult(DatabaseContext context, IWebHostEnvironment hostEnvironment) {
        _context = context;
        webHostEnvironment = hostEnvironment;
    }
    
    [BindProperty]
    public IFormFile? Urinalysis { get; set; }
    
    [BindProperty]
    public IFormFile? Fecalysis { get; set; }
    
    [BindProperty]
    public IFormFile? Cbc { get; set; }
    
    [BindProperty]
    public IFormFile? Cholesterol { get; set; }
    
    [BindProperty]
    public string SignaturePath { get; set; }
    
    
    public IActionResult OnGet()
    {
        var user = HttpContext.Session.GetLoggedInUser(_context);
        var labresult = _context.LabResults.FirstOrDefault(x => x.User == user);

        if (SignaturePath != null)
        {
            SignaturePath = Path.Combine("\\images", labresult.UrinalysisRes);
        }
       
        return Page();
    }

    public IActionResult OnPostSave()
    {
        var user = HttpContext.Session.GetLoggedInUser(_context);
        var labresult = _context.LabResults.FirstOrDefault(x => x.User == user);
        
        var imageDirectory = Path.Combine(webHostEnvironment.WebRootPath, "images");

        if (!Directory.Exists(imageDirectory))
        {
            Directory.CreateDirectory(imageDirectory);
        }
        var Urinalysisextension = Urinalysis?.FileName.Split(".").Last() ?? "jpg";
        var UrinalysisfileName = $"{Guid.NewGuid().ToString()}.{Urinalysisextension}";
        var UrinalysisfilePath = Path.Combine(imageDirectory, UrinalysisfileName);

        var Urinalysisstream = new FileStream(UrinalysisfilePath, FileMode.Create);
        Urinalysis?.CopyToAsync(Urinalysisstream);
        
        var Fecalextension = Fecalysis?.FileName.Split(".").Last() ?? "jpg";
        var FecalfileName = $"{Guid.NewGuid().ToString()}.{Fecalextension}";
        var FecalsfilePath = Path.Combine(imageDirectory, FecalfileName);

        var Fecalstream = new FileStream(FecalsfilePath, FileMode.Create);
        Fecalysis?.CopyToAsync(Fecalstream);
        
        var Cbcextension = Cbc?.FileName.Split(".").Last() ?? "jpg";
        var CbcfileName = $"{Guid.NewGuid().ToString()}.{Cbcextension}";
        var CbcfilePath = Path.Combine(imageDirectory, CbcfileName);

        var Cbcstream = new FileStream(CbcfilePath, FileMode.Create);
        Cbc?.CopyToAsync(Cbcstream);
        
        var Cholextension = Cholesterol?.FileName.Split(".").Last() ?? "jpg";
        var CholfileName = $"{Guid.NewGuid().ToString()}.{Cholextension}";
        var CholfilePath = Path.Combine(imageDirectory, CholfileName);

        var Cholstream = new FileStream(CholfilePath, FileMode.Create);
        Cbc?.CopyToAsync(Cholstream);
        
        labresult.UrinalysisRes = UrinalysisfileName;
        labresult.CbcRes = CbcfileName;
        labresult.FecalysisRes = FecalfileName;
        labresult.CholesterolRes = CholfileName;
        
        _context.SaveChanges();
        
        return Page();
    }
    
    public IActionResult OnPostRecords()
    {
        return RedirectToPage("../Homepage/Records");
    }
    
    public IActionResult OnPostDashboard()
    {
        return RedirectToPage("../Homepage/Index");
    }
    
}