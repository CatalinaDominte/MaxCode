using ClinicManagement.Core;
using ClinicManagement.Core.Repositories;
using ClinicManagement.Persistence.Repositories;

namespace ClinicManagement.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IPetRepository Pets { get; private set; }
        public IAppointmentRepository Appointments { get; private set; }
        public IAttendanceRepository Attandences { get; private set; }
        public ITypeRepository AnimalType { get; private set; }
        public IDoctorRepository Doctors { get; private set; }
        public ISpecializationRepository Specializations { get; private set; }
        public IApplicationUserRepository Users { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Pets = new PetRepository(context);
            Appointments = new AppointmentRepository(context);
            Attandences = new AttendanceRepository(context);
            AnimalType = new TypeRepository(context);
            Doctors = new DoctorRepository(context);
            Specializations = new SpecializationRepository(context);
            Users = new ApplicationUserRepository(context);

        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}