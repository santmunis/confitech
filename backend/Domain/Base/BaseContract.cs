using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    public class BaseContract<T> : IRequest<T>
    {
    }
}
