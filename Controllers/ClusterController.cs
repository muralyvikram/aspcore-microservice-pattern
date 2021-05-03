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
    public class ClusterController : ControllerBase {
        private IClusterRepository _clusterRepository;
        private readonly IMapper _mapper;
        public ClusterController (IClusterRepository clusterRepository, IMapper mapper) {
            _clusterRepository = clusterRepository ??
                throw new ArgumentNullException (nameof (clusterRepository));
            _mapper = mapper;
        }

        [HttpPost]
        [Route ("addCluster")]
        public async Task<IActionResult> CreateCluster ([FromBody] dtos.ClusterInputDto cluster) {
            var clusterContactEntity = _mapper.Map<Entities.McsClusters> (cluster);
            var clusterExists = await _clusterRepository.ClusterIfExists (clusterContactEntity.ClusterCode);
            if (clusterExists > 0) {
                return Ok ("Cluster Already Exists!");
            } else {
                await _clusterRepository.AddCluster (clusterContactEntity);
                await _clusterRepository.SaveChanges ();
            }
            return Ok (clusterContactEntity);
        }

        [HttpPost]
        [Route ("updateCluster")]
        public async Task<IActionResult> UpdateCluster ([FromBody] dtos.ClusterUpdateDto cluster) {
            var clusterContactEntity = _mapper.Map<Entities.McsClusters> (cluster);
            await _clusterRepository.UpdateCluster (clusterContactEntity);
            return Ok (clusterContactEntity);
        }

        [HttpPost]

        [Route ("getAllClusters")]
        [ProducesResponseType (typeof (dtos.ClusterViewDto), 200)]
        public async Task<IActionResult> GetAllClusters () {

            var clusterEntities = await _clusterRepository.GetClusters ();
            if (clusterEntities == null) {
                return NotFound ();
            }
            var clusterList = _mapper.Map<List<dtos.ClusterViewDto>> (clusterEntities);
            return Ok (clusterList);

        }

        [HttpPost]
        [Route ("getCluster")]
        [ProducesResponseType (typeof (dtos.ClusterViewDto), 200)]
        public async Task<IActionResult> GetCluster ([FromBody] ClusterInput cluster) {
            var clusterEntity = await _clusterRepository.GetCluster (cluster.ClusterId);
            if (clusterEntity == null) {
                return NotFound ();
            }

            var clusterInfo = _mapper.Map<dtos.ClusterViewDto> (clusterEntity);
            return Ok (clusterInfo);

        }

        [HttpPost]
        [Route ("showClustersByStatusTrue")]
        [ProducesResponseType (typeof (dtos.ClusterViewDto), 200)]
        public async Task<IActionResult> GetAllClustersByTrue () {

            var clusterEntities = await _clusterRepository.GetClustersByTrue ();
            if (clusterEntities == null) {
                return NotFound ();
            }
            var clusterList = _mapper.Map<List<dtos.ClusterViewDto>> (clusterEntities);
            return Ok (clusterList);

        }

        [HttpPost]
        [Route ("deActivateCluster")]
        public async Task<IActionResult> DeActivateCluster ([FromBody] ClusterInput cluster) {
            int result = 0;
            var clusterId = cluster.ClusterId;
            result = await _clusterRepository.DeActivateCluster (clusterId);
            return Ok (result);
        }

    }
}