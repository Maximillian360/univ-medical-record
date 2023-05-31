using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using UniversityMedicalRecord.Models;
using UniversityMedicalRecord.Models.Admin;
using UniversityMedicalRecord.Models.Employee;
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


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(CONNECTION_STRING);
    }
    
    public  IEnumerable<User> GetUsers()
    {
        var users = Users.ToList();
        return users;
    }

    public  IEnumerable<FamilyInfo> GetFamilyInfo()
    {
        var family = FamilyInfos.ToList();
        return family;
    }
    
    public  IEnumerable<Personal> GetPersonals()
    {
        var personal = Personals.ToList();
        return personal;
    }
    
    public User? GetUser(int? id)
    {
        return GetUsers().FirstOrDefault(x => x.Id == id);
    }
    
    
    public bool HasSuperAdmin()
    {
        return AdminRoles.Any(x => x.Position == Position.SuperAdmin);
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
    
    public List<User> GetAdmins()
    {
        return Users.Where(x => x.Type == UserType.Admin).ToList();
    }
    public List<AdminRole> GetAdminRoles(User admin)
    {
        return AdminRoles.Where(x => x.Admin == admin).ToList();
    }
    

}