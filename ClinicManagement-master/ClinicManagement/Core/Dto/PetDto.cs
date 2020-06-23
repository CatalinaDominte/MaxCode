using System;

namespace ClinicManagement.Core.Dto
{
    public class PetDto
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string OwnerName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public byte TypeId { get; set; }
        public AnimalTypeDto Type { get; set; }
        public int DoctorId { get; set; }
        public DoctorDto Doctor { get; set; }

        public DateTime DateTime { get; set; }
       // public string Height { get; set; }
        public string Weight { get; set; }
    }
}