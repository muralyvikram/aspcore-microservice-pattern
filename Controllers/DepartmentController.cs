using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using cms.dtos;
using cms.Models;
using cms.Services;
using Microsoft.AspNetCore.Mvc;
//using cms.Models; 
using System.Net.Http;
using AutoMapper;
using Microsoft.AspNetCore.Http;
namespace cms.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository ??
                throw new ArgumentNullException(nameof(departmentRepository));
            _mapper = mapper;
        }

        [HttpPost]
        [Route("addDepartment")]
        public async Task<IActionResult> CreateDepartment([FromBody] dtos.DepartmentInputDto department)
        {
            var departmentContactEntity = _mapper.Map<Entities.McsDepartments>(department);
            await _departmentRepository.AddDepartment(departmentContactEntity);
            await _departmentRepository.SaveChanges();

            return Ok(departmentContactEntity);
        }

        [HttpPost]
        [Route("updateDepartment")]
        public async Task<IActionResult> UpdateDepartment([FromBody] dtos.DepartmentUpdateDto department)
        {
            var departmentContactEntity = _mapper.Map<Entities.McsDepartments>(department);
            await _departmentRepository.UpdateDepartment(departmentContactEntity);
            return Ok(departmentContactEntity);
        }

    }
}
