using ClinicManagement.Core.Models;
using ClinicManagement.Persistence.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ClinicManagement.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        //public DbSet<PatientStatus> PatientStatus { get; set; }


        public ApplicationDbContext()
            : base("ClinicDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PetConfiguration());
            modelBuilder.Configurations.Add(new AppointmentConfiguration());
            modelBuilder.Configurations.Add(new DoctorConfiguration());
            modelBuilder.Configurations.Add(new AttendanceConfiguration());
            modelBuilder.Configurations.Add(new SpecializationConfiguration());
            modelBuilder.Configurations.Add(new AnimalTypeConfiguration());
            //modelBuilder.Configurations.Add(new PatientStatusConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}