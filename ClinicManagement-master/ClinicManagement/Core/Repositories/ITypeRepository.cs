using System.Collections.Generic;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Core.Repositories
{
    public interface ITypeRepository
    {
        IEnumerable<AnimalType> GetAnimalType();
    }
}