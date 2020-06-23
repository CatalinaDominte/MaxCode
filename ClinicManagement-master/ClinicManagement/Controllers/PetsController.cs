using System;
using System.Linq;
using System.Web.Mvc;
using ClinicManagement.Core;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.ViewModel;

namespace ClinicManagement.Controllers
{
    [Authorize(Roles = RoleName.DoctorRoleName + "," + RoleName.AdministratorRoleName)]
    public class PetsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PetsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            var viewModel = new PetDetailViewModel()
            {
                Pet = _unitOfWork.Pets.GetPet(id),
                Appointments = _unitOfWork.Appointments.GetAppointmentWithPet(id),
                Attendances = _unitOfWork.Attandences.GetAttendance(id),
                CountAppointments = _unitOfWork.Appointments.CountAppointments(id),
                CountAttendance = _unitOfWork.Attandences.CountAttendances(id)
            };
            return View("Details", viewModel);
        }




        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new PetFormViewModel
            {
                animalTypes = _unitOfWork.AnimalType.GetAnimalType(),
                Heading = "New Pet"
            };
            return View("PetForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.animalTypes = _unitOfWork.AnimalType.GetAnimalType();
                return View("PetForm", viewModel);

            }

            var pet = new Pet
            {
                OwnerName = viewModel.OwnerName,
                Phone = viewModel.Phone,
                Address = viewModel.Address,
                DateTime = DateTime.Now,
                Age = viewModel.Age ,
               // Height = viewModel.Height,
                Weight = viewModel.Weight,
                TypeId = viewModel.Type,
                Sex = viewModel.Sex,
                Token = (2018 + _unitOfWork.Pets.GetPet().Count()).ToString().PadLeft(7, '0')
            };

            _unitOfWork.Pets.Add(pet);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Pets");

            // TODO: BUG redirect to detail 
            //return RedirectToAction("Details", new { id = viewModel.Id });
        }


        public ActionResult Edit(int id)
        {
            var pet = _unitOfWork.Pets.GetPet(id);

            var viewModel = new PetFormViewModel
            {
                Heading = "Edit Pet",
                Id = pet.Id,
                OwnerName = pet.OwnerName,
                Phone = pet.Phone,
                Date = pet.DateTime,
                //Date = patient.DateTime.ToString("d MMM yyyy"),
                Age = pet.Age,
                Address = pet.Address,
               // Height = patient.Height,
                Weight = pet.Weight,
                Sex = pet.Sex,
                Type = pet.TypeId,
                animalTypes = _unitOfWork.AnimalType.GetAnimalType()
            };
            return View("PetForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PetFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.animalTypes = _unitOfWork.AnimalType.GetAnimalType();
                return View("PetForm", viewModel);
            }


            var petInDb = _unitOfWork.Pets.GetPet(viewModel.Id);
            petInDb.Id = viewModel.Id;
            petInDb.OwnerName = viewModel.OwnerName;
            petInDb.Phone = viewModel.Phone;
            petInDb.Age = viewModel.Age;
            petInDb.Address = viewModel.Address;
            //patientInDb.Height = viewModel.Height;
            petInDb.Weight = viewModel.Weight;
            petInDb.Sex = viewModel.Sex;
            petInDb.TypeId = viewModel.Type;

            _unitOfWork.Complete();
            return RedirectToAction("Index", "Pets")
;
        }



    }
}