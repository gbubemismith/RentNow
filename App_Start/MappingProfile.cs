using AutoMapper;
using RentNow.Dtos;
using RentNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentNow.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(m => m.Id, opt => opt.Ignore());
   
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());

           


        }
    }
}