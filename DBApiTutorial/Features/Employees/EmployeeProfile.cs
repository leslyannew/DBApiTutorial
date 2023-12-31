﻿using AutoMapper;
using DBApiTutorial.Domain;
using DBApiTutorial.Features.Employees.DTO;

namespace DBApiTutorial.Features.Employees
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();
        }
    }
}