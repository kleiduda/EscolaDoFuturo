using AutoMapper;
using Domain.Arguments.Requests;
using Domain.Arguments.Responses;
using Domain.Commands;
using Domain.Entity;
using Domain.Enums;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.ValueObject;
using Domain.ViewModels;
using Flunt.Notifications;

namespace Domain.services
{
    public class AlunoService : Notifiable, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;
        public AlunoService(IMapper mapper, IAlunoRepository alunoRepository)
        {
            _mapper = mapper;
            _alunoRepository = alunoRepository;
        }
        public async Task<ServiceResult> CadastroAluno(CadastroRequest request)
        {
            ServiceResult serviceResult = new ServiceResult();

            Documento cpf = new Documento(request.Cpf);
            if (!cpf.Valid)
            {
                serviceResult.Status = false;
                serviceResult.Notificacoes = cpf.Notifications;
                return serviceResult;
            }

            var aluno = new Aluno(request.Nome, request.SobreNome, cpf, request.Rg, ETipoPessoa.Aluno, request.Email,
            request.Telefone, request.Celular, request.DataNascimento, request.Turma, request.Periodo);

            var endereco = new Endereco(request.Pais, request.Uf, request.Cidade, request.Cep, request.Bairro,
            request.Rua, request.Numero, request.Complemento);

            AlunoCommand command = new AlunoCommand(aluno, endereco);

            int validarSeRegistoJaExiste = await _alunoRepository.ValidarRegistroNaBase(request.Cpf);
            if (validarSeRegistoJaExiste > 0)
            {
                command.AddNotification("Documento", "Já existe um aluno cadastrado com esse documento: " + aluno.Cpf);
            }

            if (!command.Valid)
            {
                serviceResult.Status = false;
                serviceResult.Notificacoes = command.Notifications;

                return serviceResult;
            }
            try
            {
                var result = await _alunoRepository.CadastrarNovoAluno(command);
                if (result)
                {
                    serviceResult.Status = result;
                    serviceResult.Mensagem = "Aluno Cadastrado com sucesso!";
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

        public async Task<ServiceResult> ListarAlunos(FilterRequest request)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                var result = _mapper.Map<IEnumerable<Aluno>, IEnumerable<AlunoViewModel>>(await _alunoRepository.ListarAlunos(request));
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

        public async Task<ServiceResult> ObterAlunoPeloCodigo(int codigoAluno)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                var result = _mapper.Map<Aluno, AlunoViewModel>(await _alunoRepository.ObterAlunoPeloCodigo(codigoAluno));
                if (result != null)
                {
                    serviceResult.Status = true;
                    serviceResult.Mensagem = "";
                    serviceResult.Data = result;
                }
                else
                {
                    serviceResult.Status = true;
                    serviceResult.Mensagem = "Aluno não encontrado";
                }

            }
            catch (Exception ex)
            {
                serviceResult.Status = false;
                serviceResult.Erro = ex.Message;
            }


            return serviceResult;
        }

        public async Task<ServiceResult> ExcluirAluno(int codigoALuno)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                bool result = await _alunoRepository.ExcluirAluno(codigoALuno);
                if (result)
                {
                    serviceResult.Status = true;
                    serviceResult.Mensagem = "Aluno excluido com sucesso!";
                }
                else
                {
                    serviceResult.Status = true;
                    serviceResult.Mensagem = "Falha ao excluir registro do Aluno";
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