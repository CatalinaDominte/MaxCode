﻿using System;

namespace ClinicManagement.Core.Models
{
    public class Appointment
    {

        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }

}
