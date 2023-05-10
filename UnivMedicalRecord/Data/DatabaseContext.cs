using Microsoft.EntityFrameworkCore;
using UniversityMedicalRecord.Models;
using UniversityMedicalRecord.Models.Admin;
using UniversityMedicalRecord.Models.Employee;

namespace UniversityMedicalRecord.Data;

public class DatabaseContext: DbContext
{
    public const string CONNECTION_STRING =
        @"Server=(localdb)\mssqllocaldb;Database=UniversityMedicalRecord;Trusted_Connection=True";
    
   
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
    
    public DbSet<Admin> Admins { get; set; }
    public DbSet<AdminRole> AdminRoles { get; set; }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeRole> EmployeeRoles { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(CONNECTION_STRING);
    }
    
    public List<User> GetUsers()
    {
        var users = Admins.Select(x => x as User).ToList();
        var employees = Employees.Select(x => x as User).ToList();
        users.AddRange(employees);
        return users;
    }
    
    public User? GetUser(int id)
    {
        return GetUsers().FirstOrDefault(x => x.Id == id);
    }

    public bool HasSuperAdmin()
    {
        return AdminRoles.Any(x => x.Position == Position.SuperAdmin);
    }
    
    public bool AddUser(User user)
    {
        switch (user)
        {
            case Admin admin:
                Admins.Add(admin);
                break;
            case Employee employee:
                Employees.Add(employee);
                break;
        }
        var changesSaved = SaveChanges();
        return changesSaved > 0;
    }

}