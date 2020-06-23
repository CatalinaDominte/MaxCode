using AutoMapper;
using ClinicManagement.Core.Dto;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;

namespace ClinicManagement.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Pet, PetDto>();
            Mapper.CreateMap<AnimalType, AnimalTypeDto>();
            Mapper.CreateMap<Doctor, DoctorDto>();
            Mapper.CreateMap<Specialization, SpecializationDto>();
            //Mapper.CreateMap<DoctorFormViewModel, Doctor>();
        }
    }
}