using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversityMedicalRecord.Data;
using UniversityMedicalRecord.Models;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class AddLab : PageModel
{
   private readonly DatabaseContext _context;
   private readonly IWebHostEnvironment webHostEnvironment;
   public AddLab(DatabaseContext context, IWebHostEnvironment hostEnvironment) {
       _context = context;
       webHostEnvironment = hostEnvironment;
   }
    
    [BindProperty]
    public DateTime LabDateCBC { get; set; }
    [BindProperty]
    public DateTime LabDateUrinalysis { get; set; }
    [BindProperty]
    public DateTime LabDateCholesterol { get; set; }
    [BindProperty]
    public DateTime LabDateCholesterolSi { get; set; }
    [BindProperty]
    public DateTime LabDateFecalysis { get; set; }
    
    [BindProperty]
    public int Wbc { get; set; }
    [BindProperty]
    public int Blast { get; set; }
    [BindProperty]
    public int Rbc { get; set; }
    [BindProperty]
    public int Hb { get; set; }
    [BindProperty]
    public int Hct { get; set; }
    [BindProperty]
    public int Plt { get; set; }
    [BindProperty]
    public int Promyelocyte { get; set; }
    [BindProperty]
    public int Myelocyte { get; set; }
    [BindProperty]
    public int Metamyelocyte { get; set; }
    [BindProperty]
    public int Stab { get; set; }
    [BindProperty]
    public int Segmenter { get; set; }
    [BindProperty]
    public int Lymphocyte { get; set; }
    [BindProperty]
    public int Monocyte { get; set; }
    [BindProperty]
    public int Eosinophil { get; set; }
    [BindProperty]
    public int Basophil { get; set; }
    [BindProperty]
    public int Esr { get; set; }
    [BindProperty]
    public int Reticulocyte { get; set; }
    [BindProperty]
    public int BleedingT { get; set; }
    [BindProperty]
    public int ClottingT { get; set; }
    [BindProperty]
    public string Malaria { get; set; }
    [BindProperty]
    public string RedCellMorph { get; set; }
    [BindProperty]
    public string Test { get; set; }
    [BindProperty]
    public string Control { get; set; }
    [BindProperty]
    public string Activity { get; set; }
    [BindProperty]
    public string PatientRatio { get; set; }
    [BindProperty]
    public string Inr { get; set; }
    [BindProperty]
    public string BloodType { get; set; }
    [BindProperty]
    
    public string Color { get; set; }
    [BindProperty]
    public string Appearance { get; set; }
    [BindProperty]
    public int Ph { get; set; }
    [BindProperty]
    public int Specgrav { get; set; }
    [BindProperty]
    public string EpithelialCells { get; set; }
    [BindProperty]
    public string MucusThread { get; set; }
    [BindProperty]
    public string AmorphousUrates { get; set; }
    [BindProperty]
    public string AmorphousPhosphates { get; set; }
    [BindProperty]
    public string Albumin { get; set; }
    [BindProperty]
    public string Sugar { get; set; }
    [BindProperty]
    public string Pregnancy { get; set; }
    [BindProperty]
    public string Crystals { get; set; }
    [BindProperty]
    public string Casts { get; set; }
    [BindProperty]
    public string OthersUrinalysis { get; set; }
    [BindProperty]
    public string PusCells { get; set; }
    [BindProperty]
    public string RBC { get; set; }
    [BindProperty]
    public string Bacteria { get; set; }
    [BindProperty]
    public string YeastCells { get; set; }
    [BindProperty]
    public string OthersMicroAnalysis { get; set; }
    [BindProperty]
    public int TradFbs { get; set; }
    [BindProperty]
    public int TradBun { get; set; }
    [BindProperty]
    public int TradCreatinine { get; set; }
    [BindProperty]
    public int TradBua { get; set; }
    [BindProperty]
    public int TradCholesterol { get; set; }
    [BindProperty]
    public int TradTriglyceride { get; set; }
    [BindProperty]
    public int TradDhdl { get; set; }
    [BindProperty]
    public int TradLdl { get; set; }
    [BindProperty]
    public string Remarks { get; set; }
    [BindProperty]
    public string OtherRemarks { get; set; }
    
    [BindProperty]
    public string RemarksSi { get; set; }
    [BindProperty]
    public string OtherRemarksSi { get; set; }
    [BindProperty]
    public int SiFbs { get; set; }
    [BindProperty]
    public int SiBun { get; set; }
    [BindProperty]
    public int SiCreatinine { get; set; }
    [BindProperty]
    public int SiBua { get; set; }
    [BindProperty]
    public int SiCholesterol { get; set; }
    [BindProperty]
    public int SiTriglyceride { get; set; }
    [BindProperty]
    public int SiDhdl { get; set; }
    [BindProperty]
    public int SiLdl { get; set; }
    [BindProperty]
    public int Sgot { get; set; }
    [BindProperty]
    public int Sgpt { get; set; }
    [BindProperty]
    public int Amylase { get; set; }
    [BindProperty]
    public int Ckmb { get; set; }
    [BindProperty]
    public int Sodium { get; set; }
    [BindProperty]
    public int Potassium { get; set; }
    [BindProperty]
    public int Chloride { get; set; }
    [BindProperty]
    public int IonizedCalcium { get; set; }
    [BindProperty]
    public int StoolPus { get; set; }
    [BindProperty]
    public int StoolRbc { get; set; }
    [BindProperty]
    public string StoolColor { get; set; }
    [BindProperty]
    public string StoolConsistency { get; set; }
    [BindProperty]
    public string OtherFindings { get; set; }
    [BindProperty]
    public string OccultBlood { get; set; }
    [BindProperty]
    public string MicroOtherFindings { get; set; }
    [BindProperty]
    public string MicroRemarks { get; set; }
    [BindProperty]
    public string StoolRemarks { get; set; }
    [BindProperty]
    public string FurtherRemarks { get; set; }
    
    [BindProperty]
    public User User { get; set; }
    
    [BindProperty]
    public int Id { get; set; }
    
    [BindProperty]
    public LabResult? CurrentLab { get; set; }
    
    [BindProperty]
    public int CurrentId { get; set; }
    
    [BindProperty]
    public Urinalysis Urinalysis { get; set; }
    
    [BindProperty]
    public Fecalysis Fecalysis { get; set; }

    [BindProperty]
    public CBC Cbc { get; set; }
    
    [BindProperty]
    public Cholesterol Cholesterol { get; set; }
    
    [BindProperty]
    public CholesterolSI CholesterolSi { get; set; }
    
    [BindProperty]
   public string? UrinalysisPath { get; set; }
   
   [BindProperty]
   public string? FecalPath { get; set; }
   
   [BindProperty]
   public string? CbcPath { get; set; }
   
   [BindProperty]
   public string? CholesPath { get; set; }
   [BindProperty]
   public string? CholesSiPath { get; set; }
    
    public IActionResult OnGet(int id)
    {
        var labresult = _context.GetLabResult().FirstOrDefault(x => x.Id == id);
        UrinalysisPath = Path.Combine("\\images", labresult.UrinalysisRes);
        FecalPath = Path.Combine("\\images", labresult.FecalysisRes);
        CbcPath = Path.Combine("\\images", labresult.CbcRes);
        CholesPath = Path.Combine("\\images", labresult.CholesterolRes);
        CholesSiPath = Path.Combine("\\images", labresult.CholesterolSiRes);

        var labid = _context.LabResult(id);
        CurrentId = id;
        CurrentLab = labid;

        var urinalysis = _context.Urinalyses.FirstOrDefault(x => x.Id == CurrentId);
        var fecalysis = _context.Fecalyses.FirstOrDefault(x => x.Id == CurrentId);
        var cbc = _context.BloodCounts.FirstOrDefault(x => x.Id == CurrentId);
        var cholesterol = _context.Cholesterols.FirstOrDefault(x => x.Id == CurrentId);
        var cholesterolSi = _context.CholesterolSis.FirstOrDefault(x => x.Id == CurrentId);

        Urinalysis = urinalysis;
        Fecalysis = fecalysis;
        Cbc = cbc;
        Cholesterol = cholesterol;
        CholesterolSi = cholesterolSi;
        
        return Page();
    }
    
    public IActionResult OnPostUpdateCholesterol()
    {
        _context.Attach(Cholesterol).State = EntityState.Modified;
        _context.Attach(CholesterolSi).State = EntityState.Modified;
        _context.SaveChanges();
        var labresult = _context.GetLabResult().FirstOrDefault(x => x.User.Id == Id);
        UrinalysisPath = Path.Combine("\\images", labresult.UrinalysisRes);
        FecalPath = Path.Combine("\\images", labresult.FecalysisRes);
        CbcPath = Path.Combine("\\images", labresult.CbcRes);
        CholesPath = Path.Combine("\\images", labresult.CholesterolRes);
        CholesSiPath = Path.Combine("\\images", labresult.CholesterolSiRes);

        var userid = _context.GetUser(Id);
        CurrentId = Id;
        
        return Page();
    }
    public IActionResult OnPostUpdateCbc()
    {
        
        var labresult = _context.GetLabResult().FirstOrDefault(x => x.User.Id == Id);
        UrinalysisPath = Path.Combine("\\images", labresult.UrinalysisRes);
        FecalPath = Path.Combine("\\images", labresult.FecalysisRes);
        CbcPath = Path.Combine("\\images", labresult.CbcRes);
        CholesPath = Path.Combine("\\images", labresult.CholesterolRes);
        CholesSiPath = Path.Combine("\\images", labresult.CholesterolSiRes);
        
        _context.Attach(Cbc).State = EntityState.Modified;
        _context.SaveChanges();
        CurrentId = Id;
        
        return Page();
    }
    

    public bool HasUrinalysis()
    {
        return _context.Urinalyses.Any(x=>x.labResult ==  CurrentLab);
    }
    public bool HasFecalysis()
    {
        return _context.Fecalyses.Any(x => x.labResult == CurrentLab);
    }
    
    public bool HasCbc()
    {
        return _context.BloodCounts.Any(x => x.labResult == CurrentLab);
    }
    
    public bool HasCholesterolSi()
    {
        return _context.CholesterolSis.Any(x => x.labResult == CurrentLab);
    }
    
    public bool HasCholesterol()
    {
        return _context.Cholesterols.Any(x => x.labResult == CurrentLab);
    }

    public IActionResult OnPostUrinalysis()
    {
        
        
        var urinalysis = new Urinalysis()
        {
            labResult = _context.LabResult(Id),
            DateRetrieved = LabDateUrinalysis,
            Color = Color,
            Appearance = Appearance,
            Ph = Ph,
            Specgrav = Specgrav,
            EpithelialCells = EpithelialCells,
            MucusThread = MucusThread,
            AmorphousUrates = AmorphousUrates,
            AmorphousPhosphates = AmorphousPhosphates,
            Albumin = Albumin,
            Sugar = Sugar,
            Pregnancy = Pregnancy,
            Crystals = Crystals,
            Casts = Casts,
            OthersUrinalysis = OthersUrinalysis,
            PusCells = PusCells,
            Rbc = RBC,
            Bacteria = Bacteria,
            YeastCells = YeastCells,
            OthersMicroAnalysis = OthersMicroAnalysis
        };
        _context.AddUrinalysis(urinalysis);
        _context.SaveChanges();
        
        var labresult = _context.GetLabResult().FirstOrDefault(x => x.Id == Id);
        UrinalysisPath = Path.Combine("\\images", labresult.UrinalysisRes);
        FecalPath = Path.Combine("\\images", labresult.FecalysisRes);
        CbcPath = Path.Combine("\\images", labresult.CbcRes);
        CholesPath = Path.Combine("\\images", labresult.CholesterolRes);
        CholesSiPath = Path.Combine("\\images", labresult.CholesterolSiRes);
        
        labresult.UrinalEncoded = true;
        _context.SaveChanges();
        
        CurrentId = Id;
        return Page();
    }

    public IActionResult OnPostFecalysis()
    {
        var fecalysis = new Fecalysis()
        {
            labResult = _context.LabResult(Id),
            DateRetrieved = LabDateFecalysis,
            StoolPusCells = StoolPus,
            StoolRbc = StoolRbc,
            Color = StoolColor,
            Consistency = StoolConsistency,
            OtherFindings = OtherFindings,
            OccultBlood = OccultBlood,
            MicroOtherFindings = MicroOtherFindings,
            MicroRemarks = MicroRemarks,
            StoolRemarks = StoolRemarks,
            FurtherRemarks = FurtherRemarks
        };
        _context.AddFecalysis(fecalysis);
        _context.SaveChanges();
        
        var labresult = _context.GetLabResult().FirstOrDefault(x => x.Id == Id);
        UrinalysisPath = Path.Combine("\\images", labresult.UrinalysisRes);
        FecalPath = Path.Combine("\\images", labresult.FecalysisRes);
        CbcPath = Path.Combine("\\images", labresult.CbcRes);
        CholesPath = Path.Combine("\\images", labresult.CholesterolRes);
        CholesSiPath = Path.Combine("\\images", labresult.CholesterolSiRes);
        
        labresult.FecalEncoded = true;
        _context.SaveChanges();
        
        CurrentId = Id;
        return Page();
    }

    public IActionResult OnPostCholesterol()
    {
        User= _context.GetUser(Id);
        var cholesterol = new Cholesterol()
        {
            labResult = _context.LabResult(Id),
            DateRetrieved = LabDateCholesterol,
            TradFbs = TradFbs,
            TradBun = TradBun,
            TradCreatinine = TradCreatinine,
            TradBua = TradBua,
            TradCholesterol = TradCholesterol,
            TradTriglyceride = TradTriglyceride,
            TradDhdl = TradDhdl,
            TradLdl = TradLdl,
            Remarks = Remarks,
            OtherRemarks = OtherRemarks,
        };

        
        _context.AddCholesterol(cholesterol);
        _context.SaveChanges();

        var labresult = _context.GetLabResult().FirstOrDefault(x => x.Id == Id);
        UrinalysisPath = Path.Combine("\\images", labresult.UrinalysisRes);
        FecalPath = Path.Combine("\\images", labresult.FecalysisRes);
        CbcPath = Path.Combine("\\images", labresult.CbcRes);
        CholesPath = Path.Combine("\\images", labresult.CholesterolRes);
        CholesSiPath = Path.Combine("\\images", labresult.CholesterolSiRes);
        
        labresult.CholesEncoded = true;
        _context.SaveChanges();
        
        CurrentId = Id;
        return Page();
    }
    
    
    public IActionResult OnPostCholesterolSi()
    {
        User= _context.GetUser(Id);

        var cholesterolsi = new CholesterolSI()
        {
            labResult = _context.LabResult(Id),
            DateRetrieved = LabDateCholesterolSi,
            SiFbs = SiFbs,
            SiBun = SiBun,
            SiCreatinine = SiCreatinine,
            SiBua = SiBua,
            SiCholesterol = SiCholesterol,
            SiTriglyceride = SiTriglyceride,
            SiDhdl = SiDhdl,
            SiLdl = SiLdl,
            Sgot = Sgot,
            Sgpt = Sgpt,
            Amylase = Amylase,
            Ckmb = Ckmb,
            Sodium = Sodium,
            Potassium = Potassium,
            Chloride = Chloride,
            IonizedCalcium = IonizedCalcium,
            Remarks = RemarksSi,
            OtherRemarks = OtherRemarksSi
        };
        
        _context.AddCholesterolSi(cholesterolsi);
        _context.SaveChanges();

        var labresult = _context.GetLabResult().FirstOrDefault(x => x.Id == Id);
        UrinalysisPath = Path.Combine("\\images", labresult.UrinalysisRes);
        FecalPath = Path.Combine("\\images", labresult.FecalysisRes);
        CbcPath = Path.Combine("\\images", labresult.CbcRes);
        CholesPath = Path.Combine("\\images", labresult.CholesterolRes);
        CholesSiPath = Path.Combine("\\images", labresult.CholesterolSiRes);
        
        labresult.CholesSiEncoded = true;
        _context.SaveChanges();
        
        CurrentId = Id;
        return Page();
    }

    public IActionResult OnPostCbc()
    {
        var bloodcount = new CBC()
        {
            labResult = _context.LabResult(Id),
            DateRetrieved = LabDateCBC,
            Wbc = Wbc,
            Blast = Blast,
            Rbc = Rbc,
            Hb = Hb,
            Hct = Hct,
            Plt = Plt,
            Promyelocyte = Promyelocyte,
            Myelocyte = Myelocyte,
            Metamyelocyte = Metamyelocyte,
            Stab = Stab,
            Segmenter = Segmenter,
            Lymphocyte = Lymphocyte,
            Monocyte = Monocyte,
            Eosinophil = Eosinophil,
            Basophil = Basophil,
            Esr = Esr,
            Reticulocyte = Reticulocyte,
            BleedingTime = BleedingT,
            ClottingTime = ClottingT,
            Malaria = Malaria,
            RedCellMorphology = RedCellMorph,
            Test = Test,
            Control = Control,
            Activity = Activity,
            PatientRatio = PatientRatio,
            Inr = Inr,
            BloodType = BloodType
        };
        _context.AddCbc(bloodcount);
        _context.SaveChanges();

        var labresult = _context.GetLabResult().FirstOrDefault(x => x.Id == Id);
        UrinalysisPath = Path.Combine("\\images", labresult.UrinalysisRes);
        FecalPath = Path.Combine("\\images", labresult.FecalysisRes);
        CbcPath = Path.Combine("\\images", labresult.CbcRes);
        CholesPath = Path.Combine("\\images", labresult.CholesterolRes);
        CholesSiPath = Path.Combine("\\images", labresult.CholesterolSiRes);
        
        labresult.CbcEncoded = true;
        _context.SaveChanges();
        
        CurrentId = Id;
        return Page();
    }

    public IActionResult OnPostDashboard()
    {
        return RedirectToPage("../Homepage/Index");
    }
}