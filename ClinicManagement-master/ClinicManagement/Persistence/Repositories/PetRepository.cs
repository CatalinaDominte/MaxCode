using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;

namespace ClinicManagement.Persistence.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext _context;
        public PetRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get all pets
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Pet> GetPet()
        {
            return _context.Pets.Include(c => c.Type);
        }

        /// <summary>
        /// /Get single pet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pet GetPet(int id)
        {
            return _context.Pets
                .Include(c => c.Type)
                .SingleOrDefault(p => p.Id == id);
            //return _context.Patients.Find(id);
        }
        /// <summary>
        /// Get newly added pets
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Pet> GetRecentPet()
        {
            return _context.Pets
                .Where(a => DbFunctions.DiffDays(a.DateTime, DateTime.Now) == 0)
                .Include(c => c.Type);
        }



        /// <summary>
        /// Add new pet
        /// </summary>
        /// <param name="pet"></param>
        public void Add(Pet pet)
        {
            _context.Pets.Add(pet);
        }
        /// <summary>
        /// Delete existing pet
        /// </summary>
        /// <param name="pet"></param>
        public void Remove(Pet pet)
        {
            _context.Pets.Remove(pet);
        }
    }
}