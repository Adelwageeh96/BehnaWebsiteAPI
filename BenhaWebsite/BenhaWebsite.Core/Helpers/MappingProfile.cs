using AutoMapper;
using BenhaWebsite.Core.Dtos.AuthenticationDtos;
using BenhaWebsite.Core.Dtos.CampDtos;
using BenhaWebsite.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Helpers
{
    public class MappingProfile : Profile
    {
		public MappingProfile()
		{
			CreateMap<CampAddEditDto, Camp>().ReverseMap();
		}

    }
}
