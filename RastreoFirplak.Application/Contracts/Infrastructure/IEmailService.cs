using RastreoFirplak.Application.Models;

namespace RastreoFirplak.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
