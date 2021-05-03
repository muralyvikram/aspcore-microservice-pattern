using System;
using System.Collections.Generic;
using AutoMapper;
using cms.dtos;
using cms.Entities;
using cms.Models;
namespace cms.dtos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<McsCompanies, CompanyOutputDto>();
            CreateMap<CompanyContactInputDto, McsContactDetails>();
            CreateMap<CompanyContactUpdateDto, McsContactDetails>();
            CreateMap<CompanyInputUpdateDto, McsCompanies>();
            CreateMap<CompanyInputDto, McsCompanies>();
            CreateMap<CompanyInputUpdateDto, List<McsCompanies>>();
            CreateMap<ClusterInputDto, McsClusters>();
            CreateMap<McsClusters, ClusterInputDto>();
            CreateMap<ClusterContactInputDto, McsContactDetails>();
            CreateMap<ClusterUpdateDto, McsClusters>();
            CreateMap<ClusterContactUpdateDto, McsContactDetails>();
            CreateMap<McsCompanies, CompanyViewDto>();
            CreateMap<McsContactDetails, CompanyViewDto>();
            CreateMap<CompanyContactUpdateDto, CompanyViewDto>();
            CreateMap<CompanyViewDto, McsCompanies>();
            CreateMap<CompanyViewDto, CompanyContactUpdateDto>();
            CreateMap<McsContactDetails, CompanyContactUpdateDto>();
            CreateMap<ClusterViewDto, McsClusters>();
            CreateMap<ClusterViewDto, ClusterContactUpdateDto>();
            CreateMap<McsClusters, ClusterViewDto>();
            CreateMap<ClusterContactUpdateDto, ClusterViewDto>();
            CreateMap<McsContactDetails, ClusterContactUpdateDto>();
            CreateMap<PlantInputDto, McsPlants>();
            CreateMap<McsPlants, PlantInputDto>();
            CreateMap<PlantContactInputDto, McsContactDetails>();
            CreateMap<McsContactDetails, PlantContactInputDto>();
            CreateMap<PlantUpdateDto, McsPlants>();
            CreateMap<McsPlants, PlantUpdateDto>();
            CreateMap<PlantContactUpdateDto, McsContactDetails>();
            CreateMap<McsContactDetails, PlantContactUpdateDto>();
            CreateMap<McsPlants, PlantViewDto>();
            CreateMap<PlantViewDto, McsPlants>();
        }
    }
}