using AutoMapper;
using Domain.Entity;
using Domain.Enums;
using Domain.ViewModels;

namespace Domain.Mapping
{
	public class AlunoMapping : Profile
	{
		public AlunoMapping()
		{
			CreateMap<Aluno, AlunoViewModel>()
			.ForMember(dest => dest.Periodo, opt => opt.MapFrom(src => Enum.Parse(typeof(EPeriodos), src.Periodo.ToString())))
			.ForMember(dest => dest.Turma, opt => opt.MapFrom(src => src.DescricaoTurma));
		}
	}
}

