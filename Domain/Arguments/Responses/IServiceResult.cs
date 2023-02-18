using System;
namespace Domain.Arguments.Responses
{
	public interface IServiceResult
	{
		public bool Status { get; set; }
		public string Mensagem { get; set; }
		public object Data { get; set; }
	}
}

