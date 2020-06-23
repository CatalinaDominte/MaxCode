using System.Collections.Generic;
using System.Linq;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Core.Repositories
{
    public interface IPetRepository
    {
        IEnumerable<Pet> GetPet();
        IEnumerable<Pet> GetRecentPet();
        //IEnumerable<Patient> GetPatientByToken(string searchTerm = null);
        Pet GetPet(int id);
        //IQueryable<Patient> GetPatientQuery(string query);
        void Add(Pet pet);
        void Remove(Pet pet);
    }
}
