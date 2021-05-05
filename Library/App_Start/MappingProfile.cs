using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Library.Models;
using Library.DTOs;

namespace Library.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Reader, ReaderDto>();
            Mapper.CreateMap<ReaderDto, Reader>();
        }
    }
}