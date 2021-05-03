using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cms.dtos;

namespace cms.Services {
    public interface IClusterRepository {

        Task<int> SaveChanges ();
        Task AddCluster (Entities.McsClusters cluster);
        Task UpdateCluster (Entities.McsClusters cluster);
        Task<IEnumerable<Entities.McsClusters>> GetClusters ();
        Task<Entities.McsClusters> GetCluster (Guid clusterId);
        Task<IEnumerable<Entities.McsClusters>> GetClustersByTrue ();
        Task<int> DeActivateCluster (Guid clusterId);
        Task<int> ClusterIfExists (string clusterCode);
    }
}