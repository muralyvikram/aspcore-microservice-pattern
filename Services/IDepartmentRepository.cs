using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cms.dtos;

namespace cms.Services {
    public interface IDepartmentRepository {

        Task<int> SaveChanges ();
        Task AddDepartment (Entities.McsDepartments department);

    }
}