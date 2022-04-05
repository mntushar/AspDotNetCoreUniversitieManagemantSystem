using AutoMapper;
using Models;
using UniversitieManagemantSystem.Models.Department;
using UniversitieManagemantSystem.Models.Student;

namespace UniversitieManagemantSystem.ConfigureServices
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<DepartmentDetailsMv, DepartmentModel>();
            CreateMap<DepartmentModel, DepartmentDetailsMv>();

            CreateMap<StudentModel, StudentCreateMv>();
            CreateMap<StudentCreateMv, StudentModel>();

            CreateMap<StudentModel, StudentEditMv>();
            CreateMap<StudentEditMv, StudentModel>();
        }
    }
}
