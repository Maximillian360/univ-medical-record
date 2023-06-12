﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;
using UniversityMedicalRecord.Models;
using UnivMedicalRecord.Models.Record;

namespace UnivMedicalRecord.Pages.Homepage;

public class AddLab : PageModel
{
   private readonly DatabaseContext _context;

    public AddLab(DatabaseContext context)
    {
        _context = context;
    }
    [BindProperty]
    public DateTime LabDateCBC { get; set; }
    [BindProperty]
    public DateTime LabDateUrinalysis { get; set; }
    [BindProperty]
    public DateTime LabDateCholesterol { get; set; }
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
    public User CurrentUser { get; set; }
    
    [BindProperty]
    public int CurrentId { get; set; }

    public IActionResult OnGet(int id)
    {
        var userid = _context.GetUser(id);
        CurrentId = id;
        CurrentUser = userid;
        return Page();
    }

    public bool HasUrinalysis()
    {
        return _context.Urinalyses.Any(x=>x.User == CurrentUser);
    }
    public bool HasFecalysis()
    {
        return _context.Fecalyses.Any(x => x.User == CurrentUser);
    }
    
    public bool HasCbc()
    {
        return _context.BloodCounts.Any(x => x.User == CurrentUser);
    }
    
    public bool HasCholesterolSi()
    {
        return _context.CholesterolSis.Any(x => x.User == CurrentUser);
    }
    
    public bool HasCholesterol()
    {
        return _context.Cholesterols.Any(x => x.User == CurrentUser);
    }

    public IActionResult OnPostUrinalysis()
    {
        
        var urinalysis = new Urinalysis()
        {
            User = _context.GetUser(Id),
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
        CurrentId = Id;
        return Page();
    }

    public IActionResult OnPostFecalysis()
    {
        var fecalysis = new Fecalysis()
        {
            User = _context.GetUser(Id),
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
        CurrentId = Id;
        return Page();
    }

    public IActionResult OnPostCholesterol()
    {
        User= _context.GetUser(Id);
        var cholesterol = new Cholesterol()
        {
            User = _context.GetUser(Id),
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

        var cholesterolsi = new CholesterolSI()
        {
            User = _context.GetUser(Id),
            DateRetrieved = LabDateCholesterol,
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
            IonizedCalcium = IonizedCalcium
        };
        _context.AddCholesterol(cholesterolsi,cholesterol);
        _context.SaveChanges();
        CurrentId = Id;
        return Page();
    }

    public IActionResult OnPostCbc()
    {
        var bloodcount = new CBC()
        {
            User = _context.GetUser(Id),
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
        CurrentId = Id;
        return Page();
    }

    public IActionResult OnPostDashboard()
    {
        return RedirectToPage("./Index");
    }
}