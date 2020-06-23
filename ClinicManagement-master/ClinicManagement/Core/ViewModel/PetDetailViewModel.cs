﻿using System.Collections.Generic;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Core.ViewModel
{
    public class PetDetailViewModel
    {
        public Pet Pet { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Attendance> Attendances { get; set; }
        public int CountAppointments { get; set; }
        public int CountAttendance { get; set; }
    }
}