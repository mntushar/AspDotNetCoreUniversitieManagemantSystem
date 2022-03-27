using AutoMapper;
using Models;
using UniversitieManagemantSystem.Models.Department;

namespace UniversitieManagemantSystem.ConfigureServices
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<DepartmentDetailsMv, DepartmentModel>();
            CreateMap<DepartmentModel, DepartmentDetailsMv>();
        }
    }
}
