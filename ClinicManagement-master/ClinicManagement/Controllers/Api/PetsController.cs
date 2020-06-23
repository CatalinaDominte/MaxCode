using AutoMapper;
using ClinicManagement.Core;
using ClinicManagement.Core.Dto;
using ClinicManagement.Core.Models;
using System.Linq;
using System.Web.Http;

namespace ClinicManagement.Controllers.Api
{
    public class PetsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public PetsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IHttpActionResult GetPets()
        {
            var petsQuery = _unitOfWork.Pets.GetPet();


            var petDto = petsQuery.ToList()
                                          .Select(Mapper.Map<Pet, PetDto>);

            return Ok(petDto);

        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var pet = _unitOfWork.Pets.GetPet(id);
            _unitOfWork.Pets.Remove(pet);
            _unitOfWork.Complete();
            return Ok();
        }

    }
}
