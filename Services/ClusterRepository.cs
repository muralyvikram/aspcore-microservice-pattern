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
    public class ClusterRepository : IClusterRepository {
        private MasterDBContext _context;
        public ClusterRepository (MasterDBContext context) {
            _context = context ??
                throw new ArgumentNullException (nameof (context));
        }

        public async Task<int> SaveChanges () {
            return await _context.SaveChangesAsync ();
        }
        public async Task AddCluster (Entities.McsClusters cluster) {
            if (cluster == null) {
                throw new ArgumentNullException (nameof (cluster));
            }
            await _context.AddAsync (cluster);

        }
        public async Task UpdateCluster (Entities.McsClusters cluster) {
            if (cluster == null) {
                throw new ArgumentNullException (nameof (cluster));
            }
            if (_context != null) {
                //Delete that post
                _context.McsClusters.Update (cluster);

                //Commit the transaction
                await this.SaveChanges ();

            }
        }
        public async Task<IEnumerable<McsClusters>> GetClusters () {
            return await _context.McsClusters.Include (c => c.Contact).ToListAsync ();

        }
        public async Task<McsClusters> GetCluster (Guid clusterId) {
            return await _context.McsClusters.Include (c => c.Contact).FirstOrDefaultAsync (b => b.ClusterId == clusterId);
        }
        public async Task<IEnumerable<McsClusters>> GetClustersByTrue () {
            return await _context.McsClusters.Include (c => c.Contact).Where (x => x.Status == true).ToListAsync ();

        }
        public async Task<int> DeActivateCluster (Guid clusterId) {
            int result = 0;
            if (_context != null) {
                var cluster = await _context.McsClusters.FirstOrDefaultAsync (x => x.ClusterId == clusterId);
                if (cluster != null) {
                    cluster.Status = false;
                    //  _context.McsCompanies.Update(company);
                    result = await this.SaveChanges ();
                }
                return result;
            }
            return result;
        }
        public async Task<int> ClusterIfExists (string clusterCode) {
            int result = 0;

            var cluster = await _context.McsClusters.FirstOrDefaultAsync (x => x.ClusterCode == clusterCode);
            if (cluster == null) {
                result = 0;
            } else {
                result = 1;
            }

            return result;

        }

    }
}