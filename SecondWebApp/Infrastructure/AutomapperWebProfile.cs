using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecondWebApp.Models;

namespace SecondWebApp.Infrastructure
{
    public class AutomapperWebProfile : AutoMapper.Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<EmployeeDomainModel, EmployeeViewModel>()
                .ForMember(destination => destination.ExtraProperty, opt => opt.MapFrom(src => src.ExtraProperty.ToString()))
                .ForMember(destination => destination.ExtraProperty2, opt => opt.MapFrom(src => src.ExtraProperty2.Encript()))
                .ForMember(destination=>destination.currentDate, opt=>opt.MapFrom(src=>src.currentDate.ToShortDateString()));



            CreateMap<EmployeeViewModel, EmployeeDomainModel>();
        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a => { a.AddProfile<AutomapperWebProfile>(); });
        }
    }

    public static class ExtensionMethod
    {
        public static string Encript(this Int32 num)
        {
            return $"Encriptando {num}";
        }
    }
}