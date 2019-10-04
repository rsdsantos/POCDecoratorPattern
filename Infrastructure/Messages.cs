using Communication.API.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Communication.API.Infrastructure
{
    public class Messages
    {
        private readonly IServiceProvider _provider;

        public Messages(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Task<string> Dispatch(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            Task<string> result = handler.Handle((dynamic)command);

            return result;
        }

        // Dispatch de IQuery
        //public T Dispatch<T>(IQuery<T> query)
        //{
        //    Type type = typeof(IQueryHandler<,>);
        //    Type[] typeArgs = { query.GetType(), typeof(T) };
        //    Type handlerType = type.MakeGenericType(typeArgs);

        //    dynamic handler = _provider.GetService(handlerType);
        //    T result = handler.Handle((dynamic)query);

        //    return result;
        //}
    }
}
