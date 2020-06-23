using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using ClinicManagement.Controllers;
using ClinicManagement.Core.Helpers;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Core.ViewModel
{
    public class PetFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string OwnerName { get; set; }

        public Gender Sex { get; set; }
        [Required]
       
        public int Age { get; set; }


        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
       // public string Height { get; set; }
        public string Weight { get; set; }

        public byte Type { get; set; }

        public DateTime Date { get; set; }

        public string Heading { get; set; }

       // public DateTime GetBirthDate()
      //  {
            //TODO: Validate BirthDate 

        //    return DateTime.Parse(string.Format("{0}", Age));
            //return DateTime.ParseExact(BirthDate, "dd/MM/yyyy", CultureInfo.CurrentCulture);
      //  }

        public IEnumerable<AnimalType> animalTypes { get; set; }



        public string Action
        {
            get
            {
                Expression<Func<PetsController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<PetsController, ActionResult>> create = (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;

            }
        }

        #region for dropdownlist

        public IEnumerable<SelectListItem> GendersList
        {
            get { return ClinicMgtHelpers.GenderToSelectList(); }
            set { }
        }

        #endregion
    }
}