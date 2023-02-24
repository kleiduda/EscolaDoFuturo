using AutoMapper;
using Domain.Arguments.Requests;
using Domain.Arguments.Responses;
using Domain.Commands;
using Domain.Entity;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.ValueObject;
using Flunt.Notifications;

namespace Domain.services
{
    public class UsuarioService : Notifiable, IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IMapper mapper, IUsuarioRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResult> CadastroUsuario(CadastroUsuarioRequest request)
        {
            ServiceResult serviceResult = new ServiceResult();
            Documento cpf = new Documento(request.Cpf);

            Usuario usuario = new Usuario(request.Usuario, new Guid(), request.Email, cpf, request.TipoUsuario);

            UsuarioCommand command = new UsuarioCommand(usuario);
            if (command.Invalid)
            {
                serviceResult.Status = false;
                serviceResult.Notificacoes = command.Notifications;
                return serviceResult;
            }

            int validarSeRegistoJaExiste = await _repository.ValidarRegistroNaBase(request.Cpf);
            if (validarSeRegistoJaExiste > 0)
            {
                serviceResult.Status = false;
                serviceResult.Mensagem = "Já existe uma usuario cadastrado com esse cpf: " + request.Cpf;

                return serviceResult;
            }
            try
            {
                var result = await _repository.CadastrarUsuario(command);
                if (result)
                {
                    serviceResult.Status = result;
                    serviceResult.Mensagem = "Usuario Cadastrada com sucesso!";
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