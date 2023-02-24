using AutoMapper;
using Domain.Arguments.Requests;
using Domain.Arguments.Responses;
using Domain.Entity;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.ValueObject;
using Domain.ViewModels;

namespace Domain.services
{
    public class ResponsavelService : IResponsavelService
    {
        private readonly IResponsavelRepository _repository;
        private readonly IMapper _mapper;

        public ResponsavelService(IResponsavelRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ServiceResult> CadastroResponsavel(CadastroRequest request)
        {
            ServiceResult serviceResult = new ServiceResult();

            Documento cpf = new Documento(request.Cpf);
            Responsavel responsavel  = new Responsavel(request.Nome, request.SobreNome, cpf, request.Rg, Enums.ETipoPessoa.Responsavel, request.Email, request.Telefone,
            request.Celular, request.DataNascimento);

            Endereco endereco = new Endereco(request.Pais, request.Uf, request.Cidade, request.Cep, request.Bairro, request.Rua, request.Numero,
            request.Complemento);

            CadastroResponsavelRequest cadastroResponsavelRequest = new CadastroResponsavelRequest(responsavel, endereco);

            int validarSeRegistoJaExiste = await _repository.ValidarRegistroNaBase(request.Cpf);
            if (validarSeRegistoJaExiste > 0)
            {
                cadastroResponsavelRequest.AddNotification("Cpf", "Já existe um responsável cadastrado com esse cpf: " + responsavel.Cpf);
            }
            if (!cadastroResponsavelRequest.Valid)
            {
                // foreach (var item in cadastroResponsavelRequest.Notifications)
                // {
                //     serviceResult.Status = false;
                //     serviceResult.Notificacoes = cadastroResponsavelRequest.Notifications;
                // }
                return serviceResult;
            }
            try
            {
                var result = await _repository.CadastrarNovoResponsavel(cadastroResponsavelRequest);
                if (result)
                {
                    serviceResult.Status = result;
                    serviceResult.Mensagem = "Responsável Cadastrado com sucesso!";
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

        public async Task<ServiceResult> ListarResponsaveis(FilterRequest request)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                var result = _mapper.Map<IEnumerable<Responsavel>, IEnumerable<ResponsavelViewModel>>(await _repository.ListarResponsaveis(request));
                if (result != null)
                {
                    serviceResult.Status = true;
                    serviceResult.Data = result;
                }
            }
            catch (Exception ex)
            {
                serviceResult.Status = true;
                serviceResult.Erro = ex.Message;
            }

            return serviceResult;
        }

        public async Task<ServiceResult> ObterResponsavelPeloCodigo(int codigo)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                var result = _mapper.Map<Responsavel, ResponsavelViewModel>(await _repository.ObterResponsavelPeloCodigo(codigo));
                if (result != null)
                {
                    serviceResult.Status = true;
                    serviceResult.Mensagem = "";
                    serviceResult.Data = result;
                }
                else
                {
                    serviceResult.Status = true;
                    serviceResult.Mensagem = "Responsável não encontrado";
                }

            }
            catch (Exception ex)
            {
                serviceResult.Status = false;
                serviceResult.Erro = ex.Message;
            }


            return serviceResult;
        }
        public async Task<ServiceResult> ExcluirResponsavel(int codigo)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                bool result = await _repository.ExcluirResponsavel(codigo);
                if (result)
                {
                    serviceResult.Status = true;
                    serviceResult.Mensagem = "Responsável excluido com sucesso!";
                }
                else
                {
                    serviceResult.Status = true;
                    serviceResult.Mensagem = "Falha ao excluir registro";
                }
            }
            catch (System.Exception ex)
            {
                serviceResult.Status = false;
                serviceResult.Erro = ex.Message + " --- " + ex.StackTrace;
            }
            return serviceResult;
        }
    }
}