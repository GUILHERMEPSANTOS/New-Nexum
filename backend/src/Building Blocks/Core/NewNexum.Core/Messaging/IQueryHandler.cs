using MediatR;
using NewNexum.Core.Communication;

namespace NewNexum.Core.Messaging
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    { }
}
