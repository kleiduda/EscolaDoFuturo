using AutoMapper;
using Domain.Entity;
using Domain.ViewModels;

namespace Domain.Mapping
{
	public class ResponsavelMapping : Profile
	{
		public ResponsavelMapping()
		{
			CreateMap<Responsavel, ResponsavelViewModel>();
		}
	}
}

