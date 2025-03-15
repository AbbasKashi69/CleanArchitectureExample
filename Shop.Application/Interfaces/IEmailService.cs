

using Shop.Application.DTOs;

namespace Shop.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequestDto request);
    }
}
