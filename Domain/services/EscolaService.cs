using AutoMapper;
using Domain.Arguments.Requests;
using Domain.Arguments.Responses;
using Domain.Commands.EscolaCommands;
using Domain.Entity;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.ValueObject;
using Flunt.Notifications;

namespace Domain.services
{
    public class EscolaService : Notifiable, IEscolaService
    {
        private readonly IMapper _mapper;
        private readonly IEscolaRepository _repository;

        public EscolaService(IMapper mapper, IEscolaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResult> CadastroEscola(CadastroEscolaRequest request)
        {
            ServiceResult serviceResult = new ServiceResult();
            Escola escola = new Escola(request.Cnpj, request.RazaoSocial, request.NomeFantasia, request.Pais, request.Estado, request.Cidade,
            request.Cep, request.Bairro, request.Rua, request.Numero, request.Complemento, request.Telefone, request.Telefone2, request.Email);

            EscolaCommand command = new EscolaCommand(escola);
            if (command.Invalid)
            {
                serviceResult.Status = false;
                serviceResult.Notificacoes = command.Notifications;
                return serviceResult;
            }

            Cnpj cnpj = new Cnpj(request.Cnpj);
            if (!cnpj.Valid)
            {
                serviceResult.Status = false;
                serviceResult.Notificacoes = cnpj.Notifications;
                return serviceResult;
            }

            int validarSeRegistoJaExiste = await _repository.ValidarRegistroNaBase(request.Cnpj);
            if (validarSeRegistoJaExiste > 0)
            {
                serviceResult.Status = false;
                serviceResult.Mensagem = "Já existe uma escola cadastrada com esse cnpj: " + request.Cnpj;

                return serviceResult;
            }
            try
            {
                var result = await _repository.CadastrarEscola(command);
                if (result)
                {
                    serviceResult.Status = result;
                    serviceResult.Mensagem = "Escola Cadastrada com sucesso!";
                }
                else
                {
                    serviceResult.Status = result;
                    serviceResult.Mensagem = "Falha ao realizar o cadastro!";
                }

            }
            catch (Exception ex)
            {
                serviceResult.Status = false;
                serviceResult.Erro = ex.Message;
            }
            return serviceResult;
        }
    }
}