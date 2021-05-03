using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cms.dtos;
using cms.Entities;
using cms.Models;
using cms.Services;
using Microsoft.EntityFrameworkCore;
namespace cms.Services {
    public class DepartmentRepository : IDepartmentRepository {
        private MasterDBContext _context;
        public DepartmentRepository (MasterDBContext context) {
            _context = context ??
                throw new ArgumentNullException (nameof (context));
        }

        public async Task<int> SaveChanges () {
            return await _context.SaveChangesAsync ();
        }
        public async Task AddDepartment (Entities.McsDepartments department) {
            if (department == null) {
                throw new ArgumentNullException (nameof (department));
            }
            await _context.AddAsync (department);

        }

    }
}