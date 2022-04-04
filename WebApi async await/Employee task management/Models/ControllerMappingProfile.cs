using AutoMapper;
using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_task_management.Models
{
    public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile()
        {
            CreateMap<Employee, EmployeeREST>().ReverseMap();
        }
    }
}