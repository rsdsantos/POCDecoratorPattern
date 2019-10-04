using Communication.API.Domain.Interfaces;
using System.Threading.Tasks;

namespace Communication.API.Application.Commands
{
    public class SendEmailCommandHandler : ICommandHandler<SendEmailCommand>
    {
        public Task<string> Handle(SendEmailCommand command)
        {  
            return Task.FromResult("Email successfully sent!");
        }
    }
}
