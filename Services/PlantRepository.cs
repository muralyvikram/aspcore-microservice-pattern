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
    public class PlantRepository : IPlantRepository {
        private MasterDBContext _context;
        public PlantRepository (MasterDBContext context) {
            _context = context ??
                throw new ArgumentNullException (nameof (context));
        }

        public async Task<int> SaveChanges () {
            return await _context.SaveChangesAsync ();
        }
        public async Task AddPlant (Entities.McsPlants plant) {
            if (plant == null) {
                throw new ArgumentNullException (nameof (plant));
            }
            await _context.AddAsync (plant);

        }
        public async Task UpdatePlant (Entities.McsPlants plant) {
            if (plant == null) {
                throw new ArgumentNullException (nameof (plant));
            }
            if (_context != null) {
                //Delete that post
                _context.McsPlants.Update (plant);

                //Commit the transaction
                await this.SaveChanges ();

            }
        }
        public async Task<IEnumerable<McsPlants>> GetPlants () {
            return await _context.McsPlants.Include (c => c.Contact).ToListAsync ();

        }
        public async Task<McsPlants> GetPlant (Guid plantId) {
            return await _context.McsPlants.Include (c => c.Contact).FirstOrDefaultAsync (b => b.PlantId == plantId);
        }
        public async Task<int> DeActivatePlant (Guid plantId) {
            int result = 0;
            if (_context != null) {
                var plant = await _context.McsPlants.FirstOrDefaultAsync (x => x.PlantId == plantId);
                if (plant != null) {
                    plant.Status = false;
                    //  _context.McsCompanies.Update(company);
                    result = await this.SaveChanges ();
                }
                return result;
            }
            return result;
        }
        public async Task<int> PlantIfExists (string plantCode) {
            int result = 0;

            var plant = await _context.McsPlants.FirstOrDefaultAsync (x => x.PlantCode == plantCode);
            if (plant == null) {
                result = 0;
            } else {
                result = 1;
            }

            return result;

        }
        public async Task<IEnumerable<McsPlants>> GetPlantsByTrue () {
            return await _context.McsPlants.Include (c => c.Contact).Where (x => x.Status == true).ToListAsync ();

        }
    }
}