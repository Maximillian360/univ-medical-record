using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using UniversityMedicalRecord.Models;
using UniversityMedicalRecord.Models.Admin;
using UniversityMedicalRecord.Models.Employee;
using UnivMedicalRecord.Models.Comms;
using UnivMedicalRecord.Models.Record;

namespace UniversityMedicalRecord.Data;

public class DatabaseContext: DbContext
{
    public const string CONNECTION_STRING =
        @"Server=(localdb)\mssqllocaldb;Database=UniversityMedicalRecord;Trusted_Connection=True";
    
   
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
   
    public DbSet<User> Users { get; set; }
    public DbSet<AdminRole> AdminRoles { get; set; }
    public DbSet<EmployeeRole> EmployeeRoles { get; set; }
    public DbSet<CBC> BloodCounts { get; set; }
    public DbSet<Urinalysis> Urinalyses { get; set; }
    public DbSet<Cholesterol> Cholesterols { get; set; }
    public DbSet<CholesterolSI> CholesterolSis { get; set; }
    public DbSet<Fecalysis> Fecalyses { get; set; }
    public DbSet<FamilyInfo> FamilyInfos { get; set; }
    public DbSet<Personal> Personals { get; set; }
    public DbSet<Medical>Medicals { get; set; }
    public DbSet<MessagePost>MessagePosts { get; set; }
    public DbSet<LabResult>LabResults { get; set; }
   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(CONNECTION_STRING);
    }
    
    public  IEnumerable<User> GetUsers()
    {
        var users = Users.ToList();
        return users;
    }
    
    

    public IEnumerable<LabResult> GetUrinalTest()
    {
        var labresult = LabResults.ToList();
        return labresult;
    }

    public  IEnumerable<FamilyInfo> GetFamilyInfo()
    {
        var family = FamilyInfos.Include(X=>X.user).ToList();
        return family;
    }
    
    public  IEnumerable<Personal> GetPersonals()
    {
        var personal = Personals.Include(x=>x.user).ToList();
        return personal;
    }
    
    public  IEnumerable<Urinalysis> GetUrinalysis()
    {
        var urinalysis = Urinalyses.Include(x=>x.labResult.User).ToList();
        return urinalysis;
    }
    
    public  IEnumerable<Cholesterol> GetCholesterol()
    {
        var cholesterol = Cholesterols.Include(x=>x.labResult.User).ToList();
        return cholesterol;
    }
    public  IEnumerable<Fecalysis> GetFecalysis()
    {
        var fecalysis = Fecalyses.Include(x=>x.labResult.User).ToList();
        return fecalysis;
    }

    public  IEnumerable<CholesterolSI> GetCholesterolSis()
    {
        var cholesterolSi = CholesterolSis.Include(x=>x.labResult.User).ToList();
        return cholesterolSi;
    }
    public  IEnumerable<CBC> GetBloodCount()
    {
        var cbc = BloodCounts.Include(X=>X.labResult.User).ToList();
        return cbc;
    }
    public User? GetUser(int? id)
    {
        return GetUsers().FirstOrDefault(x => x.Id == id);
    }

    public LabResult? LabResult(int? id)
    {
        return GetLabResult().FirstOrDefault(x => x.Id == id);
    }

    // public IEnumerable<MessagePost> GetMessage()
    // {
    //     var msg = MessagePosts.Include(x => x.message).ToList();
    //     return msg;
    // }


    public bool RemoveMessage( MessagePost messagePost)
    {
        MessagePosts.Remove(messagePost);
        var changesSaved = SaveChanges();
        return changesSaved > 0;
    }
    public bool HasSuperAdmin()
    {
        return AdminRoles.Any(x => x.Position == Position.SuperAdmin);
    }
    public bool WriteMessage(MessagePost messagePost)
    {
        MessagePosts.Add(messagePost);
        var changesSaved = SaveChanges();
        return changesSaved > 0;
    }

    
    public IEnumerable<LabResult> GetLabResult()
    {
        var labresult = LabResults.Include(x => x.User).ToList();
        return labresult;
    }
    public bool AddUser(User user)
    {
        Users.Add(user);
        var changesSaved = SaveChanges();
        return changesSaved > 0;
    }

    public bool AddRecord(Personal personal, Medical medical, FamilyInfo familyInfo)
    {
        Personals.Add(personal);
        FamilyInfos.Add(familyInfo);
        Medicals.Add(medical);
        var changesSaved = SaveChanges();
        return changesSaved > 0;
    }

    public bool AddUrinalysis(Urinalysis urinalysis)
    {
        Urinalyses.Add(urinalysis);
        var changesSaved = SaveChanges();
        return changesSaved > 0;
    }
    
    public bool AddFecalysis(Fecalysis fecalysis)
    {
        Fecalyses.Add(fecalysis);
        var changesSaved = SaveChanges();
        return changesSaved > 0;
    }
    
    public bool AddCbc(CBC cbc)
    {
        BloodCounts.Add(cbc);
        var changesSaved = SaveChanges();
        return changesSaved > 0;
    }
    
    public bool AddCholesterolSi(CholesterolSI cholesterolSi)
    {
        CholesterolSis.Add(cholesterolSi);
        var changesSaved = SaveChanges();
        return changesSaved > 0;
    }
    
    public bool AddCholesterol(Cholesterol cholesterol)
    {
        Cholesterols.Add(cholesterol);
        var changesSaved = SaveChanges();
        return changesSaved > 0;
    }
    
    public bool AddLabResult(LabResult labResult)
    {
        LabResults.Add(labResult);
        var changesSaved = SaveChanges();
        return changesSaved > 0;
    }

    
    

    public List<User> GetAdmins()
    {
        return Users.Where(x => x.Type == UserType.Admin).ToList();
    }
    public List<AdminRole> GetAdminRoles(User admin)
    {
        return AdminRoles.Where(x => x.Admin == admin).ToList();
    }
    

}