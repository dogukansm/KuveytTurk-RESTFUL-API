using System;
using System.Collections.Generic;
using System.Text;

namespace KuveytTurk.CORE.Utilities.Results
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
