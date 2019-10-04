using System.Threading.Tasks;

namespace Communication.API.Domain.Interfaces
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task<string> Handle(TCommand command);
    }
}
