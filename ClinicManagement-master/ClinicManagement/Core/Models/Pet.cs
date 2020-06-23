using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClinicManagement.Core.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string OwnerName { get; set; }
        public Gender Sex { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public byte TypeId { get; set; }
        public AnimalType Type { get; set; }
        public DateTime DateTime { get; set; }
        //public string Height { get; set; }
        public string Weight { get; set; }

      //  public int Age
       // {
          //  get
          //  {
            //    var now = DateTime.Today;
            //    var age = now.Year - Age.Year;
             //   if (Age > now.AddYears(-age)) age--;
             //   return age;
         //   }

      //  }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Attendance> Attendances { get; set; }

        public Pet()
        {
            Appointments = new Collection<Appointment>();
            Attendances = new Collection<Attendance>();
        }
    }
}