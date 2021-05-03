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
    public class CompanyRepository : ICompanyRepository {
        private MasterDBContext _context;
        public CompanyRepository (MasterDBContext context) {
            _context = context ??
                throw new ArgumentNullException (nameof (context));
        }

        public async Task<int> SaveChanges () {
            return await _context.SaveChangesAsync ();
        }
        public async Task AddCompany (Entities.McsCompanies company) {
            if (company == null) {
                throw new ArgumentNullException (nameof (company));
            }
            await _context.AddAsync (company);

        }
        public async Task UpdateCompany (Entities.McsCompanies company) {
            if (company == null) {
                throw new ArgumentNullException (nameof (company));
            }
            if (_context != null) {
                //Delete that post
                _context.McsCompanies.Update (company);

                //Commit the transaction
                await this.SaveChanges ();

            }
        }
        public async Task<int> CompanyIfExists (string companyCode) {
            int result = 0;

            var company = await _context.McsCompanies.FirstOrDefaultAsync (x => x.CompanyCode == companyCode);
            if (company == null) {
                result = 0;
            } else {
                result = 1;
            }

            return result;

        }
        public async Task<IEnumerable<McsCompanies>> GetCompanies () {
            return await _context.McsCompanies.Include (c => c.Contact).ToListAsync ();

        }
        public async Task<IEnumerable<McsCompanies>> GetCompaniesByTrue () {
            return await _context.McsCompanies.Include (c => c.Contact).Where (x => x.Status == true).ToListAsync ();

        }

        public async Task<McsCompanies> GetCompany (Guid companyId) {
            return await _context.McsCompanies.Include (c => c.Contact).FirstOrDefaultAsync (b => b.CompanyId == companyId);
        }

        public async Task<int> DeActivateCompany (Guid companyId) {
            int result = 0;
            if (_context != null) {
                var company = await _context.McsCompanies.FirstOrDefaultAsync (x => x.CompanyId == companyId);
                if (company != null) {
                    company.Status = false;
                    //  _context.McsCompanies.Update(company);
                    result = await this.SaveChanges ();
                }
                return result;
            }
            return result;
        }

    }
}