using AutoMapper;
using Domain.Entity;
using Domain.ViewModels;

namespace Domain.Mapping
{
	public class AlunoMapping : Profile
	{
		public AlunoMapping()
		{
			CreateMap<Aluno, AlunoViewModel>();
		}
	}
}

