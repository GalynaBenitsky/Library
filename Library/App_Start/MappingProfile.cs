﻿using System;
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
            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<Magazine, MagazineDto>();

            //Dto to Domain
            Mapper.CreateMap<ReaderDto, Reader>()
                .ForMember(r => r.Id, opt => opt.Ignore());

            Mapper.CreateMap<BookDto, Book>()
                .ForMember(b => b.Id, opt => opt.Ignore());

            Mapper.CreateMap<MagazineDto, Magazine>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}