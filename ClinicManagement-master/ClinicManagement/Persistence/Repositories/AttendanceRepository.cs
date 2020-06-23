using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;

namespace ClinicManagement.Persistence.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;
        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Attendance> GetAttandences()
        {
            return _context.Attendances.ToList();
        }
        /// <summary>
        /// Get attandences for single pet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Attendance> GetAttendance(int id)
        {
            return _context.Attendances.Where(p => p.PetId == id).ToList();
        }
        /// <summary>
        /// search  attandences for pet by token 
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public IEnumerable<Attendance> GetPetAttandences(string searchTerm = null)
        {
            var attandences = _context.Attendances.Include(p => p.Pet);
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                attandences = attandences.Where(p => p.Pet.Token.Contains(searchTerm));
            }
            return attandences.ToList();
        }
        /// <summary>
        /// Get number of attendances for defined pet 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CountAttendances(int id)
        {
            return _context.Attendances.Count(a => a.PetId == id);
        }
        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }
    }
}