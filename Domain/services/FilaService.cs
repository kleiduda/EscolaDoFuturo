using AutoMapper;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Flunt.Notifications;

namespace Domain.services
{
    public class FilaService : Notifiable, IFilaService
    {
        private readonly IMapper _mapper;
        private readonly IFilaRepository _repository;

        public FilaService(IMapper mapper, IFilaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
    }
}