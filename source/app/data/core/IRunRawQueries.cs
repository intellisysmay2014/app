using System;
using System.Collections.Generic;

namespace app.data.core
{
  public interface IRunRawQueries : IDisposable
  {
    IEnumerable<T> execute_for<T>();
  }
}