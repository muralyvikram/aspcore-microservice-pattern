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
namespace cms.Controllers {
    [Route ("api/[controller]")]
    public class PlantController : ControllerBase {
        private IPlantRepository _plantRepository;
        private readonly IMapper _mapper;
        public PlantController (IPlantRepository plantRepository, IMapper mapper) {
            _plantRepository = plantRepository ??
                throw new ArgumentNullException (nameof (plantRepository));
            _mapper = mapper;
        }

        [HttpPost]
        [Route ("addPlant")]
        public async Task<IActionResult> CreatePlant ([FromBody] dtos.PlantInputDto plant) {
            var plantContactEntity = _mapper.Map<Entities.McsPlants> (plant);
            var plantExists = await _plantRepository.PlantIfExists (plantContactEntity.PlantCode);
            if (plantExists > 0) {
                return Ok ("Plant Already Exists!");
            } else {
                await _plantRepository.AddPlant (plantContactEntity);
                await _plantRepository.SaveChanges ();
            }
            return Ok (plantContactEntity);
        }

        [HttpPost]
        [Route ("updatePlant")]
        public async Task<IActionResult> UpdatePlant ([FromBody] dtos.PlantUpdateDto plant) {
            var plantContactEntity = _mapper.Map<Entities.McsPlants> (plant);
            await _plantRepository.UpdatePlant (plantContactEntity);
            return Ok (plantContactEntity);
        }

        [HttpPost]

        [Route ("getAllPlants")]
        [ProducesResponseType (typeof (dtos.PlantViewDto), 200)]
        public async Task<IActionResult> GetAllPlants () {

            var plantEntities = await _plantRepository.GetPlants ();
            if (plantEntities == null) {
                return NotFound ();
            }
            var plantList = _mapper.Map<List<dtos.PlantViewDto>> (plantEntities);
            return Ok (plantList);

        }

        [HttpPost]
        [Route ("getPlant")]
        [ProducesResponseType (typeof (dtos.PlantViewDto), 200)]
        public async Task<IActionResult> GetPlant ([FromBody] PlantInput plant) {
            var plantEntity = await _plantRepository.GetPlant (plant.PlantId);
            if (plantEntity == null) {
                return NotFound ();
            }

            var plantInfo = _mapper.Map<dtos.PlantViewDto> (plantEntity);
            return Ok (plantInfo);

        }

        [HttpPost]
        [Route ("deActivatePlant")]
        public async Task<IActionResult> DeActivateCluster ([FromBody] PlantInput plant) {
            int result = 0;
            var plantId = plant.PlantId;
            result = await _plantRepository.DeActivatePlant (plantId);
            return Ok (result);
        }

        [HttpPost]
        [Route ("showPlantsByStatusTrue")]
        [ProducesResponseType (typeof (dtos.PlantViewDto), 200)]
        public async Task<IActionResult> GetAllPlantsByTrue () {

            var plantEntities = await _plantRepository.GetPlantsByTrue ();
            if (plantEntities == null) {
                return NotFound ();
            }
            var plantList = _mapper.Map<List<dtos.PlantViewDto>> (plantEntities);
            return Ok (plantList);

        }

    }
}