using System.Collections.Generic;
using System.Linq;
using ClinicManagement.Core.Dto;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;

namespace ClinicManagement.Persistence.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly ApplicationDbContext _context;

        public TypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AnimalType> GetAnimalType()
        {
            return _context.AnimalTypes.ToList();
        }
    }
}