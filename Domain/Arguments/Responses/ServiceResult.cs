namespace Domain.Arguments.Responses
{
    public class ServiceResult : IServiceResult
    {
        public ServiceResult()
        {
        }

        public ServiceResult(bool status, string mensagem, string erro, object data, string notificacoes)
        {
            Status = status;
            Mensagem = mensagem;
            Notificacoes = notificacoes;
            Erro = erro;
            Data = data;
        }

        public bool Status { get ; set ; }
        public string Mensagem { get ; set ; }
        public string Erro { get; set; }
        public object Data { get; set ; }
        public string Notificacoes { get; set; }
    }
}

