using AspNet_Api_EfCore.Models;

namespace AspNet_Api_EfCore.Interfaces
{
    public interface IEmailService
    {
        bool Send(string toName, string toEmail, string subject, string body, string fromName = "Equipe Teste", string fromEmail = "teste@teste.com.br");
    }
}
