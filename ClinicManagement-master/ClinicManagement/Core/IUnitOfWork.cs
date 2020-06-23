using ClinicManagement.Core.Repositories;

namespace ClinicManagement.Core
{
    public interface IUnitOfWork
    {
        IPetRepository Pets { get; }
        IAppointmentRepository Appointments { get; }
        IAttendanceRepository Attandences { get; }
        ITypeRepository AnimalType { get; }
        IDoctorRepository Doctors { get; }
        ISpecializationRepository Specializations { get; }
        IApplicationUserRepository Users { get; }

        void Complete();
    }
}