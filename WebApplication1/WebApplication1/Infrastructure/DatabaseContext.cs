using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<Patients> Patients { get; set; }
    public DbSet<Admissions> Admissions { get; set; }
    public DbSet<Wards> Wards { get; set; }
    public DbSet<BedAssignments> BedAssigments { get; set; }
    public DbSet<Beds> Beds { get; set; }
    public DbSet<BedTypes> BedTypes { get; set; }
    public DbSet<Rooms> Rooms { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);
    
    modelBuilder.Entity<Wards>().HasData(
        new Wards { Id = 1, Name = "Kardiologia", Description = "Oddział chorób serca i układu krążenia" },
        new Wards { Id = 2, Name = "Chirurgia", Description = "Oddział chirurgii ogólnej" },
        new Wards { Id = 3, Name = "Ortopedia", Description = "Oddział leczenia urazów i schorzeń kości" },
        new Wards { Id = 4, Name = "Pediatria", Description = "Oddział dziecięcy" },
        new Wards { Id = 5, Name = "Neurologia", Description = "Oddział chorób układu nerwowego" }
    );
    
    modelBuilder.Entity<BedTypes>().HasData(
        new BedTypes { Id = 1, Name = "Standard", Description = "Łóżko standardowe" },
        new BedTypes { Id = 2, Name = "Intensywna terapia", Description = "Łóżko OIOM" },
        new BedTypes { Id = 3, Name = "Rehabilitacyjne", Description = "Łóżko rehabilitacyjne" },
        new BedTypes { Id = 4, Name = "Dziecięce", Description = "Łóżko pediatryczne" },
        new BedTypes { Id = 5, Name = "Elektryczne", Description = "Łóżko sterowane elektrycznie" }
    );
    
    modelBuilder.Entity<Patients>().HasData(
        new Patients { Pesel = "90010112345", FirstName = "Jan", LastName = "Kowalski", Age = 35, Sex = false },
        new Patients { Pesel = "85050567890", FirstName = "Anna", LastName = "Nowak", Age = 40, Sex = true },
        new Patients { Pesel = "72031245678", FirstName = "Piotr", LastName = "Wiśniewski", Age = 53, Sex = false },
        new Patients { Pesel = "04122098765", FirstName = "Zuzanna", LastName = "Kaczmarek", Age = 20, Sex = true },
        new Patients { Pesel = "68111122233", FirstName = "Marek", LastName = "Lewandowski", Age = 57, Sex = false }
    );
    
    modelBuilder.Entity<Rooms>().HasData(
        new Rooms { Id = "A101", WardId = 1, HasTv = true },
        new Rooms { Id = "B201", WardId = 2, HasTv = true },
        new Rooms { Id = "C301", WardId = 3, HasTv = false },
        new Rooms { Id = "D401", WardId = 4, HasTv = true },
        new Rooms { Id = "E501", WardId = 5, HasTv = false }
    );
    
    modelBuilder.Entity<Beds>().HasData(
        new Beds { Id = 1, RoomId = "A101", BedTypeId = 1 },
        new Beds { Id = 2, RoomId = "B201", BedTypeId = 2 },
        new Beds { Id = 3, RoomId = "C301", BedTypeId = 3 },
        new Beds { Id = 4, RoomId = "D401", BedTypeId = 4 },
        new Beds { Id = 5, RoomId = "E501", BedTypeId = 5 }
    );
    
    modelBuilder.Entity<Admissions>().HasData(
        new Admissions { Id = 1, AdmissionDate = new DateTime(2026, 05, 01, 10, 0, 0), DischargeDate = new DateTime(2026, 05, 05, 14, 0, 0), PatientPesel = "90010112345", WardId = 1 },
        new Admissions { Id = 2, AdmissionDate = new DateTime(2026, 05, 03, 09, 30, 0), DischargeDate = null, PatientPesel = "85050567890", WardId = 2 },
        new Admissions { Id = 3, AdmissionDate = new DateTime(2026, 05, 06, 12, 15, 0), DischargeDate = new DateTime(2026, 05, 10, 11, 0, 0), PatientPesel = "72031245678", WardId = 3 },
        new Admissions { Id = 4, AdmissionDate = new DateTime(2026, 05, 08, 08, 45, 0), DischargeDate = null, PatientPesel = "04122098765", WardId = 4 },
        new Admissions { Id = 5, AdmissionDate = new DateTime(2026, 05, 09, 16, 20, 0), DischargeDate = null, PatientPesel = "68111122233", WardId = 5 }
    );
    
    modelBuilder.Entity<BedAssignments>().HasData(
        new BedAssignments { Id = 1, PatientPesel = "90010112345", BedId = 1, From = new DateTime(2026, 05, 01, 10, 30, 0), To = new DateTime(2026, 05, 05, 13, 0, 0) },
        new BedAssignments { Id = 2, PatientPesel = "85050567890", BedId = 2, From = new DateTime(2026, 05, 03, 10, 0, 0), To = null },
        new BedAssignments { Id = 3, PatientPesel = "72031245678", BedId = 3, From = new DateTime(2026, 05, 06, 12, 30, 0), To = new DateTime(2026, 05, 10, 10, 30, 0) },
        new BedAssignments { Id = 4, PatientPesel = "04122098765", BedId = 4, From = new DateTime(2026, 05, 08, 09, 0, 0), To = null },
        new BedAssignments { Id = 5, PatientPesel = "68111122233", BedId = 5, From = new DateTime(2026, 05, 09, 17, 0, 0), To = null }
    );
}
}