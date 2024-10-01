using MediatR;
using NewNexum.Core.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Core.Messaging
{
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
    
    public interface ICommand : IRequest<Result>
    {
    }
}
