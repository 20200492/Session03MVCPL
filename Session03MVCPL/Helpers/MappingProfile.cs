using AutoMapper;
using Session03MVCEDAL.Models;
using Session03MVCPL.ViewModel;

namespace Session03MVCPL.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeViewModel, Employee>();
        }
    }
}
