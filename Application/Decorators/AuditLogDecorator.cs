using Communication.API.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Communication.API.Application.Decorators
{
    public class AuditLogDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _handler;
        private readonly ILogger _logger;

        public AuditLogDecorator(ICommandHandler<TCommand> handler,
                                 ILogger<string> logger)
        {
            _handler = handler;
            _logger = logger;
        }

        public Task<string> Handle(TCommand command)
        {
            string commandJson = JsonConvert.SerializeObject(command);

            _logger.LogInformation("Starting logging...");
            _logger.LogInformation($"Command of type {command.GetType().Name}: {commandJson}");
            _logger.LogInformation("Finished logging!");

            return _handler.Handle(command);
        }
    }
}
