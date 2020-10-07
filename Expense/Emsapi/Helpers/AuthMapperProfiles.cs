using AutoMapper;
using Emsapi.Dtos;
using Emsapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emsapi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserForRegisterDto, User>();
            CreateMap<ExpenseCreationDto, Expense>();
            CreateMap<ExpenseUpdateDto, Expense>();
        }
    }
}
