using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cms.dtos;

namespace cms.Services {
    public interface IPlantRepository {

        Task<int> SaveChanges ();
        Task AddPlant (Entities.McsPlants plant);
        Task UpdatePlant (Entities.McsPlants plant);
        Task<IEnumerable<Entities.McsPlants>> GetPlants ();
        Task<Entities.McsPlants> GetPlant (Guid plantId);
        Task<int> DeActivatePlant (Guid plantId);
        Task<int> PlantIfExists (string plantCode);
        Task<IEnumerable<Entities.McsPlants>> GetPlantsByTrue ();
    }
}