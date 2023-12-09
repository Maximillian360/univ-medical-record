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
    [BindProperty]
    public decimal[] ChartValuesRBC { get; set; }
    [BindProperty]
    public decimal[] ChartValuesWBC { get; set; }
    [BindProperty]
    public decimal[] ChartValuesHb { get; set; }
    [BindProperty]
    public decimal[] ChartValuesPlt { get; set; }
    
    
    [BindProperty]
    public decimal[] ChartValuesPh { get; set; }

    [BindProperty]
    public decimal[] ChartValuesSpecgrav { get; set; }

    [BindProperty]
    public decimal[] ChartValuesPusCells { get; set; }

    [BindProperty]
    public decimal[] ChartValuesRbcUrinalysis { get; set; }
    [BindProperty]
    public decimal[] ChartValuesWBCHPF { get; set; }

    [BindProperty]
    public decimal[] ChartValuesRBCHPF { get; set; }
    [BindProperty]
    public decimal[] ChartValuesTradCholesterol { get; set; }

    [BindProperty]
    public decimal[] ChartValuesTradLDL { get; set; }
    [BindProperty]
    public decimal[] ChartValuesTradDHDL { get; set; }
    [BindProperty]
    public decimal[] ChartValuesTradTriglyceride { get; set; }
    [BindProperty]
    public decimal[] ChartValuesSiCholesterol { get; set; }
    [BindProperty]
    public decimal[] ChartValuesSiLDL { get; set; }
    [BindProperty]
    public decimal[] ChartValuesSiDHDL { get; set; }

    [BindProperty]
    public decimal[] ChartValuesSiTriglyceride { get; set; }
    
    public IQueryable<User> requestUser { get; set; }
    public bool? userHasRequest { get; set; }
    public bool HasMedicalRecord { get; set; }
    public async Task<IActionResult> OnGetAsync()
    {
        var user = HttpContext.Session.GetLoggedInUser(_context);
        var userList = _context.Users.Where(x=>x.Type == UserType.Regular);
        var lablist = _context.LabResults;
        var pendinglab = _context.GetLabResult().Where(x=>x.CholesterolRes != null &x.CholesterolSiRes != null & x.FecalysisRes != null & x.UrinalysisRes != null & x.CbcRes != null && x.CbcEncoded == false || x.CholesSiEncoded == false || x.CholesEncoded == false || x.UrinalEncoded == false || x.CbcEncoded == false);

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
        var fecalysis = _context.GetFecalysis().Where(x => x.labResult.User == user && x.DateRetrieved >= DateStart && x.DateRetrieved <= DateEnd);
        var urinalysis = _context.GetUrinalysis().Where(x => x.labResult.User == user && x.DateRetrieved >= DateStart && x.DateRetrieved <= DateEnd);
        var Cholest = _context.GetCholesterol().Where(x => x.labResult.User == user && x.DateRetrieved >= DateStart && x.DateRetrieved <= DateEnd);
        var CholestSi = _context.GetCholesterolSis().Where(x => x.labResult.User == user && x.DateRetrieved >= DateStart && x.DateRetrieved <= DateEnd);
        
        if (ChosenSummary == "CBC")
        {
            List<string> chartLabels = DateRangeList; 

            Dictionary<string, decimal> chartValuesRBC = new Dictionary<string, decimal>();
            Dictionary<string, decimal> chartValuesWBC = new Dictionary<string, decimal>();
            Dictionary<string, decimal> chartValuesHb = new Dictionary<string, decimal>();
            Dictionary<string, decimal> chartValuesPlt = new Dictionary<string, decimal>();
            Dictionary<string, int> recordCountsByMonth = new Dictionary<string, int>();

            // Initialize values for all months in DateRangeList to 0
            foreach (var month in chartLabels)
            {
                chartValuesRBC[month] = 0;
                chartValuesWBC[month] = 0;
                chartValuesHb[month] = 0;
                chartValuesPlt[month] = 0;
                recordCountsByMonth[month] = 0;
            }

            // Iterate through bloodcount and update values in the dictionary
            foreach (var x in bloodcount)
            {
                
                // Assuming DateRetrieved is a DateTime property in your model
                string dateLabel = x.DateRetrieved.ToString("MMMM yyyy");

                // Add the record value to the corresponding month
                chartValuesRBC[dateLabel] += (decimal)x.Rbc;
                chartValuesWBC[dateLabel] += (decimal)x.Wbc;
                chartValuesHb[dateLabel] += (decimal)x.Hb;
                chartValuesPlt[dateLabel] += (decimal)x.Plt;
                recordCountsByMonth[dateLabel]++;
            }
            
            foreach (var month in chartLabels)
            {
                Console.WriteLine($"{month}: RBC={chartValuesRBC[month]}, WBC={chartValuesWBC[month]}, Hb={chartValuesHb[month]}, Plt={chartValuesPlt[month]}, Count={recordCountsByMonth[month]}");
                if (recordCountsByMonth[month] > 0)
                {
                    chartValuesRBC[month] /= recordCountsByMonth[month];
                    chartValuesWBC[month] /= recordCountsByMonth[month];
                    chartValuesHb[month] /= recordCountsByMonth[month];
                    chartValuesPlt[month] /= recordCountsByMonth[month];
                }
            }
            
            ChartValuesRBC = chartValuesRBC.Values.ToArray();
            ChartValuesWBC = chartValuesWBC.Values.ToArray();
            ChartValuesHb = chartValuesHb.Values.ToArray();
            ChartValuesPlt = chartValuesPlt.Values.ToArray();

            ChartLabels = chartLabels.ToArray();
            
       
        }
        
        else if (ChosenSummary == "Urinalysis")
        { 
            List<string> chartLabels = DateRangeList; // Assuming DateRangeList is a list of months

        // Initialize dictionaries to store values for each parameter in Urinalysis
        Dictionary<string, decimal> chartValuesPh = new Dictionary<string, decimal>();
        Dictionary<string, decimal> chartValuesSpecgrav = new Dictionary<string, decimal>();
        Dictionary<string, decimal> chartValuesPusCells = new Dictionary<string, decimal>();
        Dictionary<string, decimal> chartValuesRbcUrinalysis = new Dictionary<string, decimal>();
        Dictionary<string, int> recordCountsByMonth = new Dictionary<string, int>();

        // Initialize values for all months in DateRangeList to 0
        foreach (var month in chartLabels)
        {
            chartValuesPh[month] = 0;
            chartValuesSpecgrav[month] = 0;
            chartValuesPusCells[month] = 0;
            chartValuesRbcUrinalysis[month] = 0;
            recordCountsByMonth[month] = 0;
        }

        // Iterate through urinalysis and update values in the dictionary
        foreach (var x in urinalysis)
        {
            string dateLabel = x.DateRetrieved.ToString("MMMM yyyy");

            // Add the record value to the corresponding month
            chartValuesPh[dateLabel] += (decimal)x.Ph;
            chartValuesSpecgrav[dateLabel] += (decimal)x.Specgrav;
            chartValuesPusCells[dateLabel] += (decimal)x.PusCells;
            chartValuesRbcUrinalysis[dateLabel] += (decimal)x.Rbc;
            
            // Add similar lines for other parameters (PusCells, RbcUrinalysis)

            recordCountsByMonth[dateLabel]++;
        }

        foreach (var month in chartLabels)
        {
            Console.WriteLine($"{month}: Ph={chartValuesPh[month]}, Specgrav={chartValuesSpecgrav[month]}, PusCells={chartValuesPusCells[month]}, RbcUrinalysis={chartValuesRbcUrinalysis[month]}, Count={recordCountsByMonth[month]}");

            if (recordCountsByMonth[month] > 0)
            {
                chartValuesPh[month] /= recordCountsByMonth[month];
                chartValuesSpecgrav[month] /= recordCountsByMonth[month];
                chartValuesPusCells[month] /= recordCountsByMonth[month];
                chartValuesRbcUrinalysis[month] /= recordCountsByMonth[month];
                // Divide other parameters by count here
            }
            else
            {
                Console.WriteLine($"No records for {month}");
            }
        }

        // Assign the values to the corresponding properties
        ChartValuesPh = chartValuesPh.Values.ToArray();
        ChartValuesSpecgrav = chartValuesSpecgrav.Values.ToArray();
        ChartValuesPusCells = chartValuesPusCells.Values.ToArray();
        ChartValuesRbcUrinalysis = chartValuesRbcUrinalysis.Values.ToArray();

        ChartLabels = chartLabels.ToArray();
            
        }
        
        
        else if (ChosenSummary == "Fecalysis")
        {
            List<string> chartLabels = DateRangeList; 
            Dictionary<string, decimal> chartValuesWBCHPF = new Dictionary<string, decimal>();
            Dictionary<string, decimal> chartValuesRBCHPF = new Dictionary<string, decimal>();
            Dictionary<string, int> recordCountsByMonth = new Dictionary<string, int>();
            
            foreach (var month in chartLabels)
            {
                chartValuesWBCHPF[month] = 0;
                chartValuesRBCHPF[month] = 0;
                recordCountsByMonth[month] = 0;
            }
            
            foreach (var x in fecalysis)
            {
                string dateLabel = x.DateRetrieved.ToString("MMMM yyyy");

                // Add the record value to the corresponding month
                chartValuesWBCHPF[dateLabel] += (decimal)x.StoolPusCells;
                chartValuesRBCHPF[dateLabel] += (decimal)x.StoolRbc;
                
                recordCountsByMonth[dateLabel]++;
            }
            
            foreach (var month in chartLabels)
            {
                
                if (recordCountsByMonth[month] > 0)
                {
                    chartValuesWBCHPF[month] /= recordCountsByMonth[month];
                    chartValuesRBCHPF[month] /= recordCountsByMonth[month];
                    // Divide other parameters by count here
                }
                else
                {
                    Console.WriteLine($"No records for {month}");
                }
            }
            
            ChartValuesWBCHPF = chartValuesWBCHPF.Values.ToArray();
            ChartValuesRBCHPF = chartValuesRBCHPF.Values.ToArray();
            

            ChartLabels = chartLabels.ToArray();
            
            
        }
        
        else if (ChosenSummary == "Cholesterol")
        {
            List<string> chartLabels = DateRangeList; 
            Dictionary<string, decimal> chartValuesTradCholesterol = new Dictionary<string, decimal>();
            Dictionary<string, decimal> chartValuesTradLDL = new Dictionary<string, decimal>();
            Dictionary<string, decimal> chartValuesTradDHDL = new Dictionary<string, decimal>();
            Dictionary<string, decimal> chartValuesTradTriglyceride = new Dictionary<string, decimal>();
            Dictionary<string, int> recordCountsByMonth = new Dictionary<string, int>();
            
            foreach (var month in chartLabels)
            {
                chartValuesTradCholesterol[month] = 0;
                chartValuesTradLDL[month] = 0;
                chartValuesTradDHDL[month] = 0;
                chartValuesTradTriglyceride[month] = 0;
                recordCountsByMonth[month] = 0;
            }
            
            foreach (var x in Cholest)
            {
                string dateLabel = x.DateRetrieved.ToString("MMMM yyyy");

                // Add the record value to the corresponding month
                chartValuesTradCholesterol[dateLabel] += (decimal)x.TradCholesterol;
                chartValuesTradLDL[dateLabel] += (decimal)x.TradLdl;
                chartValuesTradDHDL[dateLabel] += (decimal)x.TradDhdl;
                chartValuesTradTriglyceride[dateLabel] += (decimal)x.TradTriglyceride;
                
                recordCountsByMonth[dateLabel]++;
            }
            
            foreach (var month in chartLabels)
            {
                
                if (recordCountsByMonth[month] > 0)
                {
                    chartValuesTradCholesterol[month] /= recordCountsByMonth[month];
                    chartValuesTradLDL[month] /= recordCountsByMonth[month];
                    chartValuesTradDHDL[month] /= recordCountsByMonth[month];
                    chartValuesTradTriglyceride[month] /= recordCountsByMonth[month];
                    // Divide other parameters by count here
                }
                else
                {
                    Console.WriteLine($"No records for {month}");
                }
            }
            
            ChartValuesTradCholesterol = chartValuesTradCholesterol.Values.ToArray();
            ChartValuesTradLDL = chartValuesTradLDL.Values.ToArray();
            ChartValuesTradDHDL = chartValuesTradDHDL.Values.ToArray();
            ChartValuesTradTriglyceride = chartValuesTradTriglyceride.Values.ToArray();

            ChartLabels = chartLabels.ToArray();
            
        }
        
        
        else if(ChosenSummary == "CholesterolSi")
        {
            List<string> chartLabels = DateRangeList; 
            Dictionary<string, decimal> chartValuesSICholesterol = new Dictionary<string, decimal>();
            Dictionary<string, decimal> chartValuesSILDL = new Dictionary<string, decimal>();
            Dictionary<string, decimal> chartValuesSIDHDL = new Dictionary<string, decimal>();
            Dictionary<string, decimal> chartValuesSITriglyceride = new Dictionary<string, decimal>();
            Dictionary<string, int> recordCountsByMonth = new Dictionary<string, int>();
            
            foreach (var month in chartLabels)
            {
                chartValuesSICholesterol[month] = 0;
                chartValuesSILDL[month] = 0;
                chartValuesSIDHDL[month] = 0;
                chartValuesSITriglyceride[month] = 0;
                recordCountsByMonth[month] = 0;
            }
            
            foreach (var x in CholestSi)
            {
                string dateLabel = x.DateRetrieved.ToString("MMMM yyyy");

                // Add the record value to the corresponding month
                chartValuesSICholesterol[dateLabel] += (decimal)x.SiCholesterol;
                chartValuesSILDL[dateLabel] += (decimal)x.SiLdl;
                chartValuesSIDHDL[dateLabel] += (decimal)x.SiDhdl;
                chartValuesSITriglyceride[dateLabel] += (decimal)x.SiTriglyceride;
                
                recordCountsByMonth[dateLabel]++;
            }
            
            foreach (var month in chartLabels)
            {
                
                if (recordCountsByMonth[month] > 0)
                {
                    chartValuesSICholesterol[month] /= recordCountsByMonth[month];
                    chartValuesSILDL[month] /= recordCountsByMonth[month];
                    chartValuesSIDHDL[month] /= recordCountsByMonth[month];
                    chartValuesSITriglyceride[month] /= recordCountsByMonth[month];
                    // Divide other parameters by count here
                }
                else
                {
                    Console.WriteLine($"No records for {month}");
                }
            }
            
            ChartValuesSiCholesterol = chartValuesSICholesterol.Values.ToArray();
            ChartValuesSiLDL = chartValuesSILDL.Values.ToArray();
            ChartValuesSiDHDL = chartValuesSIDHDL.Values.ToArray();
            ChartValuesSiTriglyceride = chartValuesSITriglyceride.Values.ToArray();

            ChartLabels = chartLabels.ToArray();
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
        var pendinglab = _context.GetLabResult().Where(x=>x.CholesterolRes != null & x.CholesterolSiRes != null & x.FecalysisRes != null & x.UrinalysisRes != null & x.CbcRes != null && x.CbcEncoded == false || x.CholesSiEncoded == false || x.CholesEncoded == false || x.UrinalEncoded == false || x.CbcEncoded == false);

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
