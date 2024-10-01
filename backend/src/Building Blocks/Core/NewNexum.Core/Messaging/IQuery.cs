using MediatR;
using NewNexum.Core.Communication;

namespace NewNexum.Core.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
