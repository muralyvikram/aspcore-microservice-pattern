using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cms.dtos;

namespace cms.Services {
    public interface ICompanyRepository {

        Task<int> SaveChanges ();
        Task AddCompany (Entities.McsCompanies company);
        Task UpdateCompany (Entities.McsCompanies company);
        Task<int> CompanyIfExists (string companyCode);

        Task<IEnumerable<Entities.McsCompanies>> GetCompanies ();
        Task<IEnumerable<Entities.McsCompanies>> GetCompaniesByTrue ();
        Task<Entities.McsCompanies> GetCompany (Guid companyId);
        Task<int> DeActivateCompany (Guid companyId);
    }
}