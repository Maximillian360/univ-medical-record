using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;
using UniversityMedicalRecord.Models;
using UnivMedicalRecord.Models.Comms;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class IndexModel : PageModel
{
    private readonly DatabaseContext _context;
    public IndexModel(DatabaseContext context)  {
        _context = context;
    }
    [BindProperty]
    public string[] ChartLabels { get; set; }
    [BindProperty]
    public decimal[] ChartValues { get; set; }
    
    public IQueryable<User> requestUser { get; set; }
    public bool? userHasRequest { get; set; }
    public bool HasMedicalRecord { get; set; }
    public async Task<IActionResult> OnGetAsync()
    {
        var user = HttpContext.Session.GetLoggedInUser(_context);
        var userList = _context.Users.Where(x=>x.Type == UserType.Regular);
        var lablist = _context.LabResults;
        var pendinglab = _context.GetLabResult().Where(x=>x.CholesterolRes != null & x.FecalysisRes != null & x.UrinalysisRes != null & x.CbcRes != null && x.CbcEncoded == false || x.CholesEncoded == false || x.UrinalEncoded == false || x.CbcEncoded == false);

        var labresult = _context.GetLabResult().Where(X => X.User == user);

        var requestedUser = _context.Users.Where(x=>x.Type == UserType.Regular);
        var userhasrequest = _context.GetUser(user.Id).IsRequested;
        var hasmedrecord = _context.Medicals.Any(x => x.user == user);

        HasMedicalRecord = hasmedrecord;
        requestUser = requestedUser;
        userHasRequest = userhasrequest;
        
        LabResults = labresult;
        PendingLab = pendinglab;
        LabList = lablist;
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
  
    public IEnumerable<CBC> BloodCount { get; set; }
    public IEnumerable<Urinalysis> Urinal { get; set; }
    public IEnumerable<Fecalysis> Fecal { get; set; }
    public IEnumerable<Cholesterol> Choles { get; set; }
    public IEnumerable<CholesterolSI> CholesSi { get; set; }
    public IEnumerable<LabResult> LabResults { get; set; }
    public IQueryable<User> Users { get; set; }
    [BindProperty]
    public string Name { get; set; }
    [BindProperty]
    public string Type { get; set; }
    
    [BindProperty]
    public DateTime DateStart { get; set; }
    
    [BindProperty]
    public DateTime DateEnd { get; set; }
    [BindProperty]
    public string? ChosenSummary { get; set; }
    public IEnumerable<LabResult> PendingLab { get; set; }
    public IQueryable<LabResult> LabList { get; set; }
    public IEnumerable<LabResult> LabResultChecker { get; set; }
    public IEnumerable<LabResult> LabResultChecker1 { get; set; }
    public List<string> DateRangeList
    {
        get
        {
            List<string> dateList = new List<string>();
            TimeSpan range = DateEnd - DateStart;
            int months = (DateEnd.Year - DateStart.Year) * 12 + DateEnd.Month - DateStart.Month;

            // Include DateStart and DateEnd in the list
            for (int i = 0; i <= months; i++)
            {
                DateTime currentDate = DateStart.AddMonths(i);
                dateList.Add(currentDate.ToString("MMMM yyyy"));
            }

            return dateList;
        }
    }

    public IActionResult OnPostSelect()
    {
        var user = HttpContext.Session.GetLoggedInUser(_context);
        var bloodcount = _context.GetBloodCount().Where(x => x.labResult.User == user && x.DateRetrieved >= DateStart && x.DateRetrieved <= DateEnd);
        var fecalysis = _context.GetFecalysis().Where(x => x.labResult.User == user && x.DateRetrieved == DateStart && x.DateRetrieved <= DateEnd);
        var Cholest = _context.GetCholesterol().Where(x => x.labResult.User == user && x.DateRetrieved == DateStart && x.DateRetrieved <= DateEnd);
        var CholestSi = _context.GetCholesterolSis().Where(x => x.labResult.User == user && x.DateRetrieved == DateStart && x.DateRetrieved <= DateEnd);
        if (ChosenSummary == "CBC")
        {
            List<string> chartLabels = DateRangeList; // Assuming DateRangeList is a list of months

            // Initialize a dictionary to store values for each month
            Dictionary<string, decimal> chartValuesByMonth = new Dictionary<string, decimal>();
            Dictionary<string, int> recordCountsByMonth = new Dictionary<string, int>();

            // Initialize values for all months in DateRangeList to 0
            foreach (var month in chartLabels)
            {
                chartValuesByMonth[month] = 0;
                recordCountsByMonth[month] = 0;
            }

            // Iterate through bloodcount and update values in the dictionary
            foreach (var x in bloodcount)
            {
                // Assuming DateRetrieved is a DateTime property in your model
                string dateLabel = x.DateRetrieved.ToString("MMMM yyyy");

                // Add the record value to the corresponding month
                chartValuesByMonth[dateLabel] += (decimal)x.Rbc;
                recordCountsByMonth[dateLabel]++;
            }
            
            for (int i = 0; i < chartLabels.Count; i++)
            {
                string month = chartLabels[i];
                if (recordCountsByMonth[month] > 0)
                {
                    chartValuesByMonth[month] /= recordCountsByMonth[month];
                }
            }

            // Convert dictionary values to an array
            ChartValues = chartValuesByMonth.Values.ToArray();
            ChartLabels = chartLabels.ToArray();
            
            
            
            // List<string> chartLabels = new List<string>();
            // List<decimal> chartValues = new List<decimal>();
            // foreach (var x in bloodcount)
            // {
            //     string dateLabel = x.DateRetrieved.ToString("MMMM yyyy");
            //     if (!chartLabels.Contains(dateLabel))
            //     {
            //         chartLabels.Add(dateLabel);
            //         chartValues.Add((decimal)x.Rbc);
            //     }
            //     else
            //     {
            //         int index = chartLabels.IndexOf(dateLabel);
            //         chartValues[index] += (decimal)x.Rbc;
            //     }
            // }
            //
            // ChartLabels = chartLabels.ToArray();
            // ChartValues = chartValues.ToArray();
            
            
            
            // foreach (var x in bloodcount)
            // {
            //     ChartLabels = DateRangeList.ToArray();
            //     ChartValues = new[] { (decimal)x.Rbc};
            // }
        }
        else if (ChosenSummary == "Fecalysis")
        {
            foreach (var x in fecalysis)
            {
                ChartLabels = new[] { "Stool Pus Cells" };
                ChartValues = new[] {(decimal)x.StoolPusCells,};
            }
        }
        else if (ChosenSummary == "Cholesterol")
        {
            foreach (var x in Cholest)
            {
                ChartLabels = new[] { "Cholesterol", "High-density lipoprotein", "Low-density lipoprotein","Triglycerides"  };
                ChartValues = new[] {(decimal)x.TradCholesterol,(decimal)x.TradLdl,(decimal)x.TradDhdl,(decimal)x.TradTriglyceride};
            }
        }
        else if(ChosenSummary == "Cholesterol SI")

        {
            foreach (var x in CholestSi)
            {
                ChartLabels = new[] { "Cholesterol", "High-density lipoprotein", "Low-density lipoprotein", "Triglycerides" };
                ChartValues = new[] {(decimal)x.SiCholesterol,(decimal)x.SiDhdl,(decimal)x.SiLdl,(decimal)x.SiTriglyceride};
            }
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

    public IActionResult OnPostRequest(int? id)
    {
        var user = HttpContext.Session.GetLoggedInUser(_context);
        var requestedUser = _context.Users.FirstOrDefault(x=>x.Id == id && x.Type == UserType.Regular);

        requestedUser.IsRequested = true;
        _context.SaveChanges();
        
         var requestUserList = _context.Users.Where(x=>x.Type == UserType.Regular);
         requestUser = requestUserList;
        var userList = _context.Users.Where(x=>x.Type == UserType.Regular);
        var lablist = _context.LabResults;
        var pendinglab = _context.GetLabResult().Where(x=>x.CholesterolRes != null & x.FecalysisRes != null & x.UrinalysisRes != null & x.CbcRes != null && x.CbcEncoded == false || x.CholesEncoded == false || x.UrinalEncoded == false || x.CbcEncoded == false);

        var labresult = _context.GetLabResult().Where(X => X.User == user);
        
          
        LabResults = labresult;
        PendingLab = pendinglab;
        LabList = lablist;
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
    public IActionResult OnPostLogout()
    {
        HttpContext.Session.Logout();
        return RedirectToPage("../Index");
        
    }
    
    public IActionResult OnPostLabTest()
    {
        return RedirectToPage("../LaboratoryRecord/AddLab");
       
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
        return RedirectToPage("../GeneralRecord/GeneralRecords");
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
    public IActionResult OnPostViewRecords()
    {
        return RedirectToPage("./Records");
    }
    
}
