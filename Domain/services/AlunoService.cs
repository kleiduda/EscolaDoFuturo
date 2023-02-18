using AutoMapper;
using Domain.Arguments.Requests;
using Domain.Arguments.Responses;
using Domain.Entity;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
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
        public async Task<ServiceResult> CadastroAluno(CadastroAlunoRequest request)
        {
            ServiceResult serviceResult = new ServiceResult();

            int validarSeRegistoJaExiste = await _alunoRepository.ValidarRegistroNaBase(request.Documento);
            if(validarSeRegistoJaExiste > 0){
                request.AddNotification("Documento","Já existe um aluno cadastrado com esse documento: " + request.Documento);
            }

            if(!request.Valid){
                foreach (var item in request.Notifications)
                {
                    serviceResult.Status = false;
                    serviceResult.Notificacoes = item.Message;
                }
                return serviceResult;
            }
            try
            {
                var aluno = new Aluno();
                var result = await _alunoRepository.CadastrarNovoAluno(request);
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